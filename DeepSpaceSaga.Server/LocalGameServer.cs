namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private GameSession _session;
    private readonly ReaderWriterLockSlim _sessionLock = new ReaderWriterLockSlim();
    private ConcurrentBag<Command> _tickCommands = new ConcurrentBag<Command>();
    private ConcurrentBag<Command> _turnCommands = new ConcurrentBag<Command>();

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

    private void EventsCalculation()
    {
        if (_session.IsRunning == false) return;

        EventsCalculation(1);
    }

    internal void EventsCalculation(int turns = 1)
    {
        _sessionLock.EnterWriteLock();

        _session = new TurnCalculator().Execute(_session, new List<Command>(_turnCommands));

        _turnCommands = [];

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

        _session = new TurnTickCalculator().Execute(_session, new List<Command>(_tickCommands));

        _session.TurnTick++;

        _tickCommands = [];

        _sessionLock.ExitWriteLock();

        _isCalculationInProgress = false;
    }

    public async Task AddCommand(Command command)
    {
        try
        {
            // The calculation granularity has been reduced to 10 times per second for smooth movement of objects on the map.
            if (command.Category == CommandCategory.Navigation)
            {
                _tickCommands.Add(command);
                return;
            }

            _turnCommands.Add(command);

        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
