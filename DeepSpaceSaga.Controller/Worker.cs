namespace DeepSpaceSaga.Controller;

public class Worker
{
    public event Action<GameSessionData> OnGetDataFromServer;
    public event Action<GameSessionData> OnGameInitialize;

    private IGameServer _gameServer;

    public void Initialize()
    {
        _gameServer = new LocalGameServer();
        _gameServer.SessionInitialization();
        OnGameInitialize?.Invoke(_gameServer.GetSession());

        Scheduler.Instance.ScheduleTask(1, 100, GetDataFromServer);
    }

    public void Resume()
    {
        _gameServer.ResumeSession();
    }

    public void Pause()
    {
        _gameServer.PauseSession();
    }

    private void GetDataFromServer()
    {
        OnGetDataFromServer?.Invoke(_gameServer.GetSession());
    }
}
