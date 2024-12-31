namespace DeepSpaceSaga.Universe;

public interface IGameSession
{
    // Basic properties
    int Id { get; }
    SessionMetrics Metrics { get; }
    CelestialMap SpaceMap { get; }
    Journal Logbook { get; }
    GameSessionsSettings Settings { get; }
    GameState State { get; }
    GameActionEvents Events { get; }
}