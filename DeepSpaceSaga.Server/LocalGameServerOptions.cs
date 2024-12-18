public class LocalGameServerOptions
{
    public int InitialTurnDelay { get; set; } = 1;
    public int TurnInterval { get; set; } = 100;
    public GameSessionsSettings SessionSettings { get; set; } = new();
    public CelestialMap InitialMap { get; set; } = new([]);
}