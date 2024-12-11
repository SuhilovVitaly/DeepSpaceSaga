namespace DeepSpaceSaga.Controller;

public class Worker
{
    public event Action<GameSession>? OnGetDataFromServer;
    public event Action<GameSession>? OnGameInitialize;

    private IGameServer _gameServer;

    public Worker()
    {
        _gameServer = new LocalGameServer();
    }

    public void Initialize()
    {
        
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

    public GameSession GetGameSession()
    {
        return _gameServer.GetSession();
    }

    private void GetDataFromServer()
    {
        OnGetDataFromServer?.Invoke(_gameServer.GetSession());
    }

    public async Task SendCommandAsync(Command command)
    {
        try
        {
            await _gameServer.AddCommand(command);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void SetGameSpeed(int speed)
    {
        _gameServer.SetGameSpeed(speed);

        if(_gameServer.GetSession().IsRunning == false)
        {
            _gameServer.ResumeSession();
        }
    }
}
