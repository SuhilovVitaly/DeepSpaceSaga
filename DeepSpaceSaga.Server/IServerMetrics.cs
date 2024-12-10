namespace DeepSpaceSaga.Server;

public interface IServerMetrics
{
    int TickCounter { get; }
    int TurnCounter { get; }
    void IncreaseTick();
    void IncreaseTurn();

    void Add(Metrics metric, double incrementValue);

    void Add(Metrics metric);

    double Get(Metrics metric);
}
