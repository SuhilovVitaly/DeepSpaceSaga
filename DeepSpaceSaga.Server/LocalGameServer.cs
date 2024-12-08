namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private GameSession _session;
    private readonly ReaderWriterLockSlim _sessionLock = new();
    private GameEventsSystem _gameEventsSystem = new();

    public LocalGameServer()
    {
        _session = new GameSession(new CelestialMap(new List<ICelestialObject>()));

        Scheduler.Instance.ScheduleTask(1, 100, TurnExecute);
    }

    public GameSession GetSession()
    {
        return _session.Copy();
    }

    public void PauseSession()
    {
        _session.IsRunning = false;
    }

    public void ResumeSession()
    {
        _session.IsRunning = true;
    }

    public void SessionInitialization(int sessionId = -1)
    {
        _session = GameSessionGenerator.ProduceSession();
    }

    private bool _isCalculationInProgress = false;

    private void TurnExecute()
    {
        if (_session.IsRunning == false) return;

        Execution(1);
    }
    internal void Execution(int turns = 1)
    {       
        if (_isCalculationInProgress) return;

        _isCalculationInProgress = true;

        _sessionLock.EnterWriteLock();

        _session = new TurnCalculator().Execute(_session, _gameEventsSystem);

        _session.TurnTick++;

        _sessionLock.ExitWriteLock();

        _isCalculationInProgress = false;
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            command.Status = CommandStatus.PreProcess;
            _gameEventsSystem.AddCommand(command);
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
