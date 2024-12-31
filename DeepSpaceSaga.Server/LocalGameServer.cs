namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    public event Action<GameSession>? OnTickExecute;
    public event Action<GameSession>? OnTurnExecute;

    private readonly IGameEngine _engine;      
    private readonly LocalGameServerOptions _options;
    private readonly ReaderWriterLockSlim _sessionLock = new();
    private readonly IServerMetrics _metrics;
    private SessionContext _sessionContext;
    private CancellationTokenSource _cancellationTokenSource = new();

    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    public SessionContext SessionContext 
    { 
        get => _sessionContext;
        private set => _sessionContext = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IServerMetrics Metrics 
    { 
        get => _metrics;
        private init => _metrics = value ?? throw new ArgumentNullException(nameof(value));
    }

    
    public LocalGameServer(
        IServerMetrics metrics,
        LocalGameServerOptions options,
        IGameActionEvents actions,
        IGameEngine gameEngine,
        GenerationTool randomizer,
        GameEventsSystem? eventsSystem = null)
    {
        ArgumentNullException.ThrowIfNull(metrics);
        ArgumentNullException.ThrowIfNull(options);
        
        _options = options;
        Metrics = metrics;

        _engine = gameEngine;

        SessionContext = new SessionContext(
            new GameSession(_options.InitialMap, _options.SessionSettings), 
            eventsSystem ?? new GameEventsSystem(metrics, actions),
            metrics,
            randomizer,
            _options);

        HandlersTurnInitialization();

        _engine.OnTickExecute += TickExecute;
        _engine.OnTurnExecute += TurnExecute;
    }

    public LocalGameServer(GameSession session, ServerMetrics metrics, IGameActionEvents actions, GenerationTool randomizer)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(metrics);

        Metrics = metrics;
        SessionContext = new SessionContext(
            session,
            new GameEventsSystem(metrics, actions),
            metrics,
            randomizer,
            new LocalGameServerOptions());

        HandlersTurnInitialization();
    }

    private ConcurrentBag<ICalculationHandler> HandlersTurnInitialization() => HandlersFactory.GetTurnHandlers();

    private ConcurrentBag<ICalculationHandler> HandlersTickInitialization() => HandlersFactory.GetTickHandlers();

    public GameSession GetSession()
    {
        return SessionContext.Session.Copy();
    }

    public void PauseSession()
    {
        try
        {
            SessionContext.Session.State.IsPaused = true;
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] PauseSession error: " + ex.Message);
        }        
    }

    public void ResumeSession()
    {
        try
        {
            SessionContext.Session.State.IsPaused = false;
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] ResumeSession error: " + ex.Message);
        }        
    }

    public async Task SessionInitialization(int sessionId = -1)
    {
        SessionContext.Session = GameSessionGenerator.ProduceSession(SessionContext.Randomizer);
        await Task.CompletedTask;
    }

    private bool _isCalculationInProgress = false;

    private void TurnExecute()
    {
        TurnExecute(_cancellationTokenSource.Token);
        OnTurnExecute?.Invoke(GetSession());
    }

    private void TurnExecute(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested || SessionContext.Session.State.IsPaused) 
            return;

        HandlersTurnInitialization();

        Execution();
    }

    private void TickExecute()
    {
        TickExecute(_cancellationTokenSource.Token);

        OnTickExecute?.Invoke(GetSession());
    }

    private void TickExecute(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested || SessionContext.Session.State.IsPaused)
            return;

        HandlersTickInitialization();

        ExecutionTick();
    }

    private readonly object _calculationLock = new object();

    internal void ExecutionTick()
    {
        // First check if calculation is already in progress using lock
        if (!Monitor.TryEnter(_calculationLock))
        {
            return; // Another thread is already executing
        }

        try
        {
            // Double-check pattern with volatile flag
            if (_isCalculationInProgress)
            {
                return;
            }

            _isCalculationInProgress = true;

            // Try to acquire write lock with timeout to prevent deadlocks
            if (!_sessionLock.TryEnterWriteLock(TimeSpan.FromSeconds(2)))
            {
                Logger.Info("[LocalGameServer] Failed to acquire write lock within timeout");
                return;
            }

            try
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    SessionContext = TurnExecutor.Execute(SessionContext, HandlersTickInitialization());
                }
                finally
                {
                    stopwatch.Stop();
                    Logger.Debug($"[LocalGameServer] Turn execution took {stopwatch.ElapsedMilliseconds}ms");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"[LocalGameServer] Execution error: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                if (_sessionLock.IsWriteLockHeld)
                {
                    _sessionLock.ExitWriteLock();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] Execution error: " + ex.Message);
        }
        finally
        {
            _isCalculationInProgress = false;
            Monitor.Exit(_calculationLock);
        }
    }

    internal void Execution()
    {
        // First check if calculation is already in progress using lock
        if (!Monitor.TryEnter(_calculationLock))
        {
            return; // Another thread is already executing
        }

        try
        {
            // Double-check pattern with volatile flag
            if (_isCalculationInProgress)
            {
                return;
            }

            _isCalculationInProgress = true;

            // Try to acquire write lock with timeout to prevent deadlocks
            if (!_sessionLock.TryEnterWriteLock(TimeSpan.FromSeconds(2)))
            {
                Logger.Info("[LocalGameServer] Failed to acquire write lock within timeout");
                return;
            }

            try
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    SessionContext = TurnExecutor.Execute(SessionContext, HandlersTurnInitialization());
                }
                finally
                {
                    stopwatch.Stop();
                    Logger.Debug($"[LocalGameServer] Turn execution took {stopwatch.ElapsedMilliseconds}ms");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"[LocalGameServer] Execution error: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                if (_sessionLock.IsWriteLockHeld)
                {
                    _sessionLock.ExitWriteLock();
                }
            }      
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] Execution error: " + ex.Message);
        }
        finally
        {
            _isCalculationInProgress = false;
            Monitor.Exit(_calculationLock);
        }
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            command.Status = CommandStatus.PreProcess;
            SessionContext.EventsSystem.AddCommand(command);
            var celestialObject = SessionContext.Session.GetCelestialObject(command.CelestialObjectId);

            // TODO: Move to PreProcessing block
            if (celestialObject is ISpacecraft spacecraft)
            {
                var module = spacecraft.GetModule(command.ModuleId);

                if(module != null)
                {
                    module.TargetId = command.TargetCelestialObjectId;
                    module.Execute();
                }                
            }

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] AddCommand error: " + ex.Message);
            throw;
        }
    }

    public void SetGameSpeed(int speed)
    {
        SessionContext.Session.State.SetSpeed(speed);
    }

    public void Shutdown()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }
}
