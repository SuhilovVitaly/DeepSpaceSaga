namespace DeepSpaceSaga.Server.GameLoop.Flow;

public interface IFlowContext
{
    GameSession Session { get; set; } 

    GameEventsSystem EventsSystem { get; set; }

    IServerMetrics Metrics { get; set; }

    GenerationTool Randomizer { get; set; } 

    LocalGameServerOptions Settings { get; set; } 
}
