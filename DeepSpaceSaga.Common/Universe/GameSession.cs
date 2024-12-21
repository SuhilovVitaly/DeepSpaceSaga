namespace DeepSpaceSaga.Universe;

public class GameSession
{
    public GameSession(CelestialMap spaceMap)
    {
        SpaceMap = spaceMap;
        Settings = new GameSessionsSettings();
        State = new GameState();
    }

    public GameSession(CelestialMap spaceMap, GameSessionsSettings settings)
    {
        SpaceMap = spaceMap;
        Settings = settings;
        State = new GameState();
    }

    public int Id { get; set; }

    public SessionMetrics Metrics { get; set; } = new SessionMetrics();

    public CelestialMap SpaceMap { get; internal set; }

    public Journal Logbook { get; internal set; } = new Journal([]);

    public GameSessionsSettings Settings { get; set; }

    public GameState State { get; set; }
}
