namespace DeepSpaceSaga.Server;

public class SessionContext(GameSession session, GameEventsSystem eventsSystem, IServerMetrics metrics)
{
    public GameSession Session { get; set; } = session;

    public GameEventsSystem EventsSystem { get; set; } = eventsSystem;

    public IServerMetrics Metrics { get; set; } = metrics;
}
