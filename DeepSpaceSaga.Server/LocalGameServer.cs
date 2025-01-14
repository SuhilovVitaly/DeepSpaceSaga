namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    public event Action<GameSession>? OnTickExecute;
    public event Action<GameSession>? OnTurnExecute;

    private readonly IGameEngine _engine;      
    private readonly ILocalGameServerOptions _options;
    private readonly ThreadSafeExecutor _executor = new();
    private readonly IServerMetrics _metrics;
    private IFlowContext _sessionContext;
    private CancellationTokenSource _cancellationTokenSource = new();

    private static readonly ILog Logger = LogManager.GetLogger(typeof(LocalGameServer));

    public IFlowContext SessionContext 
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
        ILocalGameServerOptions options,
        IGameActionEvents actions,
        IGameEngine gameEngine,
        IGenerationTool randomizer,
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

    private void TurnExecute()
    {
        TurnExecute(_cancellationTokenSource.Token);
        OnTurnExecute?.Invoke(GetSession());
    }

    private void TurnExecute(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested || SessionContext.Session.State.IsPaused) 
            return;

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

        //ExecutionTick();
    }

    internal void ExecutionTick()
    {
        _executor.ExecuteWithLock(() =>
        {
            SessionContext = TurnExecutor.ExecuteTick(SessionContext);
            return SessionContext;
        }, "ExecutionTick");
    }

    internal void Execution()
    {
        _executor.ExecuteWithLock(() =>
        {
            SessionContext = TurnExecutor.Execute(SessionContext);
            return SessionContext;
        }, "Execution");
    }

    public async Task AddCommand(ICommand command)
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

    public void QuickSave()
    {
        _executor.ExecuteWithLock(() =>
        {
            _ = new SaveLoadManager().Save(SessionContext.Session.SpaceMap, "QuickSave.json");

            return SessionContext;
        }, "Execution");
    }

    public void QuickLoad()
    {
        _executor.ExecuteWithLock(() =>
        {
            SessionContext = new SaveLoadManager().Load("QuickSave.json");
            return SessionContext;
        }, "Execution");
    }

    public void Load(string saveName)
    {
        _executor.ExecuteWithLock(() =>
        {
            SessionContext = new SaveLoadManager().Load(saveName + ".json");
            return SessionContext;
        }, "Execution");
    }
}
