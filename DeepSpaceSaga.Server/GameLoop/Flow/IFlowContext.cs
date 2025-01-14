namespace DeepSpaceSaga.Server.GameLoop.Flow;

public interface IFlowContext
{
    GameSession Session { get; set; } 

    GameEventsSystem EventsSystem { get; set; }

    IServerMetrics Metrics { get; set; }

    IGenerationTool Randomizer { get; set; }

    ILocalGameServerOptions Settings { get; set; } 
}
