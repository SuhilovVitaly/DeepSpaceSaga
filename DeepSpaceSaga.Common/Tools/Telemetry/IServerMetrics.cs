namespace DeepSpaceSaga.Common.Tools.Telemetry;

public interface IServerMetrics
{
    int TickCounter { get; }
    int TurnCounter { get; }
    void IncreaseTick();
    void IncreaseTurn();

    void Add(Metrics metric, double incrementValue);

    void AddMilliseconds(Metrics metric, double milliseconds);

    void Add(Metrics metric);

    double Get(Metrics metric);
}
