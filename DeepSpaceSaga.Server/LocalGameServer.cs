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
        try
        {
            SessionContext.Session.IsRunning = false;
            SessionContext.Session.State.IsPaused = true;
        }
        catch (Exception ex)
        {
            throw;
        }        
    }

    public void ResumeSession()
    {
        try
        {
            SessionContext.Session.IsRunning = true;
            SessionContext.Session.State.IsPaused = false;
        }
        catch (Exception ex)
        {
            throw;
        }        
    }

    public void SessionInitialization(int sessionId = -1)
    {
        SessionContext.Session = GameSessionGenerator.ProduceSession();
    }

    private bool _isCalculationInProgress = false;

    private void TurnExecute()
    {
        if (SessionContext.Session.IsRunning == false) return;

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

            _sessionLock.ExitWriteLock();

            _isCalculationInProgress = false;
        }
        catch (Exception ex)
        {

            throw;
        }
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

    public void SetGameSpeed(int speed)
    {
        SessionContext.Session.State.SetSpeed(speed);
    }
}
