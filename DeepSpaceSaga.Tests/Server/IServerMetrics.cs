namespace DeepSpaceSaga.Tests.Server;

public interface IServerMetrics
{
    int TickCounter { get; }
    int TurnCounter { get; }
    void IncreaseTick();
    void IncreaseTurn();
}
