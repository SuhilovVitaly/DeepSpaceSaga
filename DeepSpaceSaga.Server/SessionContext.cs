namespace DeepSpaceSaga.Server;

public class SessionContext : IFlowContext
{
    public GameSession Session { get; set; }

    public GameEventsSystem EventsSystem { get; set; }

    public IServerMetrics Metrics { get; set; }

    public IGenerationTool Randomizer { get; set; }

    public LocalGameServerOptions Settings { get; set; }

    public SessionContext()
    {

    }

    public SessionContext(GameSession session, GameEventsSystem eventsSystem, IServerMetrics metrics, IGenerationTool randomizer, LocalGameServerOptions settings)
    {
        Settings = settings;
        Randomizer = randomizer;
        Metrics = metrics;
        EventsSystem = eventsSystem;
        Session = session;
    }
}
