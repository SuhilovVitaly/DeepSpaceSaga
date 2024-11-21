namespace DeepSpaceSaga.Server;

public class LocalGameServer : IGameServer
{
    private GameSessionData _session;

    public LocalGameServer()
    {
        _session = new GameSessionData();

        Scheduler.Instance.ScheduleTask(1, 100, LocationCalculation);
        Scheduler.Instance.ScheduleTask(1, 1000, EventsCalculation);
    }

    public GameSessionData GetSession()
    {
        if(_session == null) return new GameSessionData();

        return _session.DeepClone();
    }

    public void PauseSession()
    {
        _session.IsRunning = false;
    }

    public void ResumeSession()
    {
        _session.IsRunning = true;
    }

    public void SessionInitialization()
    {
        
    }

    public void EventsCalculation()
    {
        if (_session.IsRunning == false) return;

        _session.Turn++;
        _session.TurnTick = 0;
    }

    public void LocationCalculation()
    {
        if (_session.IsRunning == false) return;

        _session.TurnTick++;
    }
}
