namespace DeepSpaceSaga.Server;

public class GameServerService(
    IServerMetrics metrics, 
    IGenerationTool randomizer,
    ILocalGameServerOptions settings,
    IGameEngine engine) : IGameServerService
{
    public IGameServer Start()
    {
        var server = new LocalGameServer(
            metrics, 
            settings, 
            new GameActionEvents(new List<GameActionEvent>()),
            engine, 
            randomizer);

        return server;
    }
}
