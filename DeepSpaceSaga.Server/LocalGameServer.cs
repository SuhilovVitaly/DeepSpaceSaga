using DeepSpaceSaga.Common.Tools;
using DeepSpaceSaga.Server.Generation;

namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private GameSession _session;
    private readonly ReaderWriterLockSlim _sessionLock = new ReaderWriterLockSlim();

    public LocalGameServer()
    {
        _session = new GameSession();

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

    public void EventsCalculation()
    {
        if (_session.IsRunning == false) return;

        _sessionLock.EnterWriteLock();

        _session.Turn++;
        _session.TurnTick = 0;

        _sessionLock.ExitWriteLock();
    }

    public void LocationCalculation()
    {
        if (_session.IsRunning == false) return;

        _sessionLock.EnterWriteLock();

        _session.TurnTick++;

        _sessionLock.ExitWriteLock();
    }
}
