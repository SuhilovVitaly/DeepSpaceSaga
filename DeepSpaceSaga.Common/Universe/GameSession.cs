namespace DeepSpaceSaga.Universe;

public class GameSession
{
    public GameSession(CelestialMap spaceMap) : this(spaceMap, new GameSessionsSettings()) { }

    public GameSession(CelestialMap spaceMap, GameSessionsSettings settings)
    {
        SpaceMap = spaceMap;
        Settings = settings;
        State = new GameState();
    }

    public int Id { get; set; }

    public SessionMetrics Metrics { get; internal set; } = new SessionMetrics();

    public CelestialMap SpaceMap { get; internal set; }

    public Journal Logbook { get; internal set; } = new Journal(new List<EventMessage>());

    public GameSessionsSettings Settings { get; internal set; }

    public GameState State { get; internal set; }
}
