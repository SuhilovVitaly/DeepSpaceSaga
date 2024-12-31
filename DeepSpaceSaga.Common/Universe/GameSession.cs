namespace DeepSpaceSaga.Universe;

public class GameSession(CelestialMap spaceMap, GameSessionsSettings settings) : IGameSession
{
    public GameSession(CelestialMap spaceMap) : this(spaceMap, new GameSessionsSettings()) { }

    public int Id { get; set; }

    public SessionMetrics Metrics { get; private set; } = new SessionMetrics();

    public CelestialMap SpaceMap { get; private set; } = spaceMap ?? throw new ArgumentNullException(nameof(spaceMap));

    public Journal Logbook { get; private set; } = new Journal(new List<EventMessage>());

    public GameSessionsSettings Settings { get; private set; } = settings ?? throw new ArgumentNullException(nameof(settings));

    public GameState State { get; private set; } = new GameState();

    public GameActionEvents Events { get; set; } = new GameActionEvents([]);
}
