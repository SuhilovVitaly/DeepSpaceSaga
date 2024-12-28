using log4net;

namespace DeepSpaceSaga.Controller;

public interface IWorker
{
    Task Initialize();
    void Resume();
    void Pause();
    GameSession GetGameSession();
    Task SendCommandAsync(Command command, CancellationToken cancellationToken = default);
    void SetGameSpeed(int speed);
}

public class Worker : IWorker
{
    private readonly ILog _logger;
    private readonly IGameServer _gameServer;

    public event Action<GameSession>? OnGetDataFromServer;
    public event Action<GameSession>? OnGameInitialize;

    public Worker(IGameServer gameServer)
    {
        _gameServer = gameServer ?? throw new ArgumentNullException(nameof(gameServer));
        _logger = LogManager.GetLogger(typeof(Worker));
    }

    public async Task Initialize()
    {
        try
        {
            await _gameServer.SessionInitialization();
            
            var session = _gameServer.GetSession();
            OnGameInitialize?.Invoke(session);
            _logger.Info("Game initialized successfully");

            Scheduler.Instance.ScheduleTask(1, 100, GetDataFromServer);
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to initialize game session", ex);
            throw;
        }
    }

    private void GetDataFromServer()
    {
        try
        {
            var handlers = OnGetDataFromServer;
            var session = _gameServer.GetSession();
            if (handlers != null)
            {
                handlers.Invoke(session);
            }
            _logger.Info($"Turn: {session.Metrics.TurnsTicks}");
        }
        catch (Exception ex)
        {
            _logger.Error("Error while getting data from server", ex);
        }
    }

    public async Task SendCommandAsync(Command command, CancellationToken cancellationToken = default)
    {
        try
        {
            await _gameServer.AddCommand(command);
        }
        catch (OperationCanceledException)
        {
            _logger.Info("Command sending was cancelled");
            throw;
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to send command", ex);
            throw;
        }
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

    public void SetGameSpeed(int speed)
    {
        _gameServer.SetGameSpeed(speed);

        if(_gameServer.GetSession().State.IsPaused)
        {
            _gameServer.ResumeSession();
        }
    }
}
