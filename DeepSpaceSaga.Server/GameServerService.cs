namespace DeepSpaceSaga.Server;

public class GameServerService(
    IGameEngine _engine, 
    IServerMetrics _metrics, 
    IGenerationTool _randomizer, 
    ILocalGameServerOptions _settings) : IGameServerService
{
    public IGameServer Start()
    {
        var server = new LocalGameServer(
            _metrics, 
            _settings, 
            new GameActionEvents([]),
            _engine, 
            _randomizer);

        return server;
    }
}
