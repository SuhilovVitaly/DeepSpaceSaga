using DeepSpaceSaga.Server.Infrastructure;

namespace DeepSpaceSaga.Server;

public class SessionContext(GameSession session, GameEventsSystem eventsSystem, IServerMetrics metrics, GenerationTool randomizer)
{
    public GameSession Session { get; set; } = session;

    public GameEventsSystem EventsSystem { get; set; } = eventsSystem;

    public IServerMetrics Metrics { get; set; } = metrics;

    public GenerationTool Randomizer { get; set; } = randomizer;

    public ConcurrentBag<ICalculationHandler> CalculationHandlers { get; set; }
}
