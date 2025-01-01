namespace DeepSpaceSaga.Server;

public class LocalGameServerOptions
{
    public int InitialTurnDelay { get; set; } = 1;
    public int TurnInterval { get; set; } = 100;
    public int TickInterval { get; set; } = 32;
    public GameSessionsSettings SessionSettings { get; set; } = new();
    public CelestialMap InitialMap { get; set; } = new([]);

    public double RatePerSecond()
    {
        return 1 / (double)TickInterval;
    }
}