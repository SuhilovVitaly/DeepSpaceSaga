namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private GameSession _session;
    private readonly ReaderWriterLockSlim _sessionLock = new ReaderWriterLockSlim();
    private ConcurrentBag<Command> _commands = new ConcurrentBag<Command>();

    public LocalGameServer()
    {
        _session = new GameSession(new CelestialMap(new List<ICelestialObject>()));

        Scheduler.Instance.ScheduleTask(1, 100, LocationCalculation);
        Scheduler.Instance.ScheduleTask(1, 1000, EventsCalculation);
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

    internal void EventsCalculation()
    {
        if (_session.IsRunning == false) return;

        _sessionLock.EnterWriteLock();

        _session.Turn++;
        _session.TurnTick = 0;

        _sessionLock.ExitWriteLock();
    }

    private bool _isCalculationInProgress = false;

    private void LocationCalculation()
    {
        if (_session.IsRunning == false) return;

        LocationCalculation(1);
    }
    internal void LocationCalculation(int turns = 1)
    {
        
        if (_isCalculationInProgress) return;

        _isCalculationInProgress = true;

        _sessionLock.EnterWriteLock();

        _session = new TurnTickCalculator().Execute(_session, new List<Command>(_commands));

        _session.TurnTick++;

        _commands = [];

        _sessionLock.ExitWriteLock();

        _isCalculationInProgress = false;
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            _commands.Add(command);
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
