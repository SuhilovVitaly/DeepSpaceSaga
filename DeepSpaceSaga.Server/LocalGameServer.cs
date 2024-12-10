namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private readonly ReaderWriterLockSlim _sessionLock = new();
    private SessionContext _sessionContext;

    public LocalGameServer()
    {
        _sessionContext = new SessionContext(new GameSession(new CelestialMap([])), new GameEventsSystem());

        Scheduler.Instance.ScheduleTask(1, 100, TurnExecute);
    }

    public LocalGameServer(GameSession session)
    {
        _sessionContext = new SessionContext(session, new GameEventsSystem());
    }

    public GameSession GetSession()
    {
        return _sessionContext.Session.Copy();
    }

    public void PauseSession()
    {
        _sessionContext.Session.IsRunning = false;
    }

    public void ResumeSession()
    {
        _sessionContext.Session.IsRunning = true;
    }

    public void SessionInitialization(int sessionId = -1)
    {
        _sessionContext.Session = GameSessionGenerator.ProduceSession();
    }

    private bool _isCalculationInProgress = false;

    private void TurnExecute()
    {
        if (_sessionContext.Session.IsRunning == false) return;

        Execution(1);
    }
    internal void Execution(int turns = 1)
    {       
        if (_isCalculationInProgress) return;

        _isCalculationInProgress = true;

        _sessionLock.EnterWriteLock();

        _sessionContext = TurnCalculator.Execute(_sessionContext, turns);

        _sessionLock.ExitWriteLock();

        _isCalculationInProgress = false;
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            command.Status = CommandStatus.PreProcess;
            _sessionContext.EventsSystem.AddCommand(command);
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
