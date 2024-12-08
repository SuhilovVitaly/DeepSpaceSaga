namespace DeepSpaceSaga.Server;

public class SessionContext(GameSession session, GameEventsSystem eventsSystem)
{
    internal GameSession Session { get; set; } = session;

    internal GameEventsSystem EventsSystem { get; set; } = eventsSystem;
}
