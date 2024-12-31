﻿namespace DeepSpaceSaga.Controller;

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
    private readonly ILog _logger = LogManager.GetLogger(typeof(Worker));
    private readonly IGameServer _gameServer;

    public event Action<GameSession>? OnGetDataFromServer;
    public event Action<GameSession>? OnGameInitialize;

    public Worker(IGameServer gameServer)
    {
        _gameServer = gameServer ?? throw new ArgumentNullException(nameof(gameServer));
        _gameServer.OnTickExecute += Server_OnTickExecute;
        _gameServer.OnTurnExecute += Server_OnTurnExecute;
    }

    private void Server_OnTickExecute(GameSession session)
    {
        OnGetDataFromServer?.Invoke(session);

        if (session.State.IsPaused == false)
        {
            //_logger.Info($"Turn: {session.Metrics.TurnsTicks}");
        }
    }

    private void Server_OnTurnExecute(GameSession session)
    {
        OnGetDataFromServer?.Invoke(session);

        if (session.State.IsPaused == false)
        {
            //_logger.Info($"Turn: {session.Metrics.TurnsTicks}");
        }
    }

    public async Task Initialize()
    {
        try
        {
            await _gameServer.SessionInitialization();
            
            var session = _gameServer.GetSession();
            OnGameInitialize?.Invoke(session);
            _logger.Info("Game initialized successfully");

            //Scheduler.Instance.ScheduleTask(1, 100, GetDataFromServer);
        }
        catch (Exception ex)
        {
            _logger.Error("Failed to initialize game session", ex);
            throw;
        }
    }

    int _prevTurn = 0;

    private void GetDataFromServer()
    {
        try
        {
            var handlers = OnGetDataFromServer;
            var session = _gameServer.GetSession();
            if (handlers != null)// && session.Metrics.TurnsTicks > _prevTurn)
            {
                handlers.Invoke(session);

                //if (session.State.IsPaused == false)
                //{
                //    _logger.Info($"Turn: {session.Metrics.TurnsTicks}");
                //}
            }            

            _prevTurn = session.Metrics.TurnsTicks;
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
