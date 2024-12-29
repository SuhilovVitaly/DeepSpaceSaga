namespace DeepSpaceSaga.Server;

public class LocalGameServerOptions
{
    public int InitialTurnDelay { get; set; } = 1;
    public int TurnInterval { get; set; } = 16;
    public int TickInterval { get; set; } = 16;
    public GameSessionsSettings SessionSettings { get; set; } = new();
    public CelestialMap InitialMap { get; set; } = new([]);

    public double RatePerSecond()
    {
        return (TurnInterval / 1000.0) * 10.0;
    }
}