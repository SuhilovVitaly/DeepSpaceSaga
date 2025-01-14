namespace DeepSpaceSaga.Server;

public class GameServerService(
    IServerMetrics metrics, 
    IGenerationTool randomizer,
    ILocalGameServerOptions settings,
    IGameEngine engine) : IGameServerService
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    
    public GameServerService(
        IServerMetrics metrics,
        IGenerationTool randomizer, 
        ILocalGameServerOptions settings,
        IGameEngine engine,
        IHost host) : this(metrics, randomizer, settings, engine)
    {
        ServiceProvider = host.Services;
    }

    public IGameServer Start()
    {
        var server = new LocalGameServer(
            metrics, 
            settings, 
            new GameActionEvents([]),
            engine, 
            randomizer);

        return server;
    }
}
