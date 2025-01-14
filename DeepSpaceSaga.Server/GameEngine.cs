namespace DeepSpaceSaga.Server;

public class GameEngine: IGameEngine
{
    public event Action? OnTickExecute;
    public event Action? OnTurnExecute;

    private readonly ILocalGameServerOptions _options;
    private readonly IServerMetrics _metrics;
    private readonly int _ticksInTurn;
    private int _currentTick;

    private static readonly ILog _logger = LogManager.GetLogger(typeof(GameEngine));

    public GameEngine(ILocalGameServerOptions options, IServerMetrics metrics)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(metrics);
        
        _options = options;
        _metrics = metrics;
        _ticksInTurn = _options.TurnInterval / _options.TickInterval;

        _logger.Info($"Initialize for {_ticksInTurn} ticks in turn.");
        _metrics.Add(Metrics.GameEngineInitializated);

        ConfigureScheduler();
    }

    private void ConfigureScheduler()
    {
        Scheduler.Instance.ScheduleTask(
            _options.InitialTurnDelay,
            _options.TickInterval,
            TickExecute);
    }

    private void TickExecute()
    {
        _currentTick++;
        
        if (_currentTick >= _ticksInTurn)
        {
            ResetAndExecuteTurn();
        }
        else
        {
            OnTickExecute?.Invoke();
        }
        
        _logger.Debug($"Current tick: {_currentTick}");
    }

    private void ResetAndExecuteTurn()
    {
        _currentTick = 0;
        OnTurnExecute?.Invoke();
    }
}
