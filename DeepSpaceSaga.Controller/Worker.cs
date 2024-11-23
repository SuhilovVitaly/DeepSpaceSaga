namespace DeepSpaceSaga.Controller;

public class Worker
{
    public event Action<GameManager>? OnGetDataFromServer;
    public event Action<GameManager>? OnGameInitialize;

    private IGameServer _gameServer;

    public Worker()
    {
        _gameServer = new LocalGameServer();
    }

    public void Initialize()
    {
        
        _gameServer.SessionInitialization();
        OnGameInitialize?.Invoke(new GameManager(_gameServer.GetSession()));

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

    public GameManager GetGameManager()
    { 
        return new GameManager(_gameServer.GetSession()); 
    }

    private void GetDataFromServer()
    {
        OnGetDataFromServer?.Invoke(new GameManager(_gameServer.GetSession()));
    }
}
