namespace DeepSpaceSaga.Controller;

public class Worker
{
    public event Action<GameSessionData> OnTurnRefresh;
    public event Action<GameSessionData> OnGetDataFromServer;

    public void Run()
    {
        Scheduler.Instance.ScheduleTask(1, 100, GetDataFromServer);
        Scheduler.Instance.ScheduleTask(1, 1000, TurnRefresh);
    }

    private void TurnRefresh()
    {
        OnTurnRefresh?.Invoke(new GameSessionData());
    }

    private void GetDataFromServer()
    {
        OnGetDataFromServer?.Invoke(new GameSessionData());
    }
}
