namespace DeepSpaceSaga.Server;

public class GameEngine: IGameEngine
{
    public event Action? OnTickExecute;
    public event Action? OnTurnExecute;

    private readonly LocalGameServerOptions _options;
    private readonly IServerMetrics _metrics;
    private int _ticksInTurn;
    private int _currentTick;

    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    public  GameEngine(LocalGameServerOptions options, IServerMetrics metrics)
    {
        _options = options;
        _metrics = metrics;

        _ticksInTurn = _options.TurnInterval / _options.TickInterval;

        Logger.Info($"Initialize for {_ticksInTurn} ticks in turn.");

        _metrics.Add(Metrics.GameEngineInitializated);

        Scheduler.Instance.ScheduleTask(
            _options.InitialTurnDelay,
            _options.TickInterval,
            TickExecute);
    }

    private void TickExecute()
    {
        _currentTick++;

        if(_currentTick >= _ticksInTurn)
        {
            _currentTick = 0;
            OnTurnExecute?.Invoke();
        }
        else
        {
            OnTickExecute?.Invoke();
        }
        Logger.Debug($"Turn: {_currentTick}");
    }
}
