namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType); 
    
    private readonly LocalGameServerOptions _options;
    private readonly ReaderWriterLockSlim _sessionLock = new();
    private readonly IServerMetrics _metrics;
    private SessionContext _sessionContext;
    private CancellationTokenSource _cancellationTokenSource = new();

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
        GenerationTool randomizer,
        GameEventsSystem? eventsSystem = null)
    {
        ArgumentNullException.ThrowIfNull(metrics);
        ArgumentNullException.ThrowIfNull(options);
        
        _options = options;
        Metrics = metrics;

        SessionContext = new SessionContext(
            new GameSession(_options.InitialMap, _options.SessionSettings), 
            eventsSystem ?? new GameEventsSystem(metrics),
            metrics,
            randomizer);

        Scheduler.Instance.ScheduleTask(
            _options.InitialTurnDelay, 
            _options.TurnInterval, 
            TurnExecute);
    }

    public LocalGameServer(GameSession session, ServerMetrics metrics, GenerationTool randomizer)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(metrics);

        Metrics = metrics;
        SessionContext = new SessionContext(
            session,
            new GameEventsSystem(metrics),
            metrics,
            randomizer);
    }

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
    }

    private void TurnExecute(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested || SessionContext.Session.State.IsPaused) 
            return;

        Execution();
    }
    internal void Execution()
    {
        try
        {
            if (_isCalculationInProgress) return;

            _isCalculationInProgress = true;

            _sessionLock.EnterWriteLock();

            SessionContext = TurnCalculator.Execute(SessionContext);
        }
        catch (Exception ex)
        {
            Logger.Error("[LocalGameServer] Execution error: " + ex.Message);
        }
        finally
        {
            if (_sessionLock.IsWriteLockHeld)
            {
                _sessionLock.ExitWriteLock();
            }
            _isCalculationInProgress = false;
        }
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            command.Status = CommandStatus.PreProcess;
            SessionContext.EventsSystem.AddCommand(command);
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
