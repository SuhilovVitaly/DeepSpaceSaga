namespace DeepSpaceSaga.Server;

public class LocalGameServerOptions: ILocalGameServerOptions
{
    public int InitialTurnDelay { get; set; } = 1;
    public int TurnInterval { get; set; } = 32;
    public int TickInterval { get; set; } = 32;
    public GameSessionsSettings SessionSettings { get; set; } = new();
    public CelestialMap InitialMap { get; set; } = new([]);

    public double RatePerSecond()
    {
        return 1 / (double)TickInterval;
    }
}

public interface ILocalGameServerOptions
{
    int InitialTurnDelay { get; set; }
    int TurnInterval { get; set; }
    int TickInterval { get; set; }
    GameSessionsSettings SessionSettings { get; set; }
    CelestialMap InitialMap { get; set; }
    double RatePerSecond();
}