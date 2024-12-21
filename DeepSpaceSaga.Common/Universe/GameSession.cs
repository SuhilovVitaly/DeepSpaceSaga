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

    public int Turn { get; set; } = 0;

    public int TurnTick { get; set; } = 0;

    public int TurnsTicks { get; set; } = 0;

    public CelestialMap SpaceMap { get; internal set; }

    public Journal Logbook { get; internal set; } = new Journal(new List<EventMessage>());

    public GameSessionsSettings Settings { get; set; }

    public GameState State { get; set; }
}
