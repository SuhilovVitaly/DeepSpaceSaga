namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private readonly ReaderWriterLockSlim _sessionLock = new();
    public SessionContext SessionContext { get; private set; }
    public IServerMetrics Metrics { get; set; }

    public LocalGameServer()
    {
        Metrics = new ServerMetrics();

        SessionContext = new SessionContext(
            new GameSession(new CelestialMap([]), new GameSessionsSettings()), 
            new GameEventsSystem(Metrics),
            Metrics);

        Scheduler.Instance.ScheduleTask(1, 100, TurnExecute);
    }

    public LocalGameServer(GameSession session, ServerMetrics metrics)
    {
        Metrics = metrics;
        SessionContext = new SessionContext(session, new GameEventsSystem(metrics), metrics);
    }

    public GameSession GetSession()
    {
        return SessionContext.Session.Copy();
    }

    public void PauseSession()
    {
        SessionContext.Session.IsRunning = false;
    }

    public void ResumeSession()
    {
        SessionContext.Session.IsRunning = true;
    }

    public void SessionInitialization(int sessionId = -1)
    {
        SessionContext.Session = GameSessionGenerator.ProduceSession();
    }

    private bool _isCalculationInProgress = false;

    private void TurnExecute()
    {
        if (SessionContext.Session.IsRunning == false) return;

        Execution(1);
    }
    internal void Execution(int turns = 1)
    {       
        if (_isCalculationInProgress) return;

        _isCalculationInProgress = true;

        _sessionLock.EnterWriteLock();

        SessionContext = TurnCalculator.Execute(SessionContext, turns);

        _sessionLock.ExitWriteLock();

        _isCalculationInProgress = false;
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            command.Status = CommandStatus.PreProcess;
            SessionContext.EventsSystem.AddCommand(command);
        }
        catch (Exception)
        {

            throw;
        }
        
    }

    public void DecreaseGameSpeed()
    {
        SessionContext.Session.Speed.Decrease();
    }
    public void IncreaseGameSpeed()
    {
        SessionContext.Session.Speed.Increase();
    }
}
