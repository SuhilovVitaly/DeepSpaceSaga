namespace DeepSpaceSaga.Tests.TestsFramework;

internal class Generator
{
    public static LocalGameServer LocalGameServer()
    {
        var options = new LocalGameServerOptions();
        var metrics = new ServerMetrics();

        var _gameServer = new LocalGameServer(metrics, options, new GameActionEvents([]), new GameEngine(options, metrics), new GenerationTool());
        _gameServer.SessionInitialization();

        return _gameServer;
    }

    public static LocalGameServer LocalGameServerWithPreSetSessoin(GameSession session)
    {
        var _gameServer = new LocalGameServer(session, new ServerMetrics(), new GameActionEvents([]), new GenerationTool());

        return _gameServer;
    }

    public static GameSessionsSettings TestsSessionsSettings()
    {
        return new GameSessionsSettings
        {
            AsteroidGenerationRatio = 1000
        };
    }

    public static ISpacecraft SpacecraftWithModules(GenerationTool? randomizer = null)
    {
        if(randomizer is null)
        {
            randomizer = new GenerationTool();
        }

        ISpacecraft spacecraft = SpacecraftGenerator.GetPlayerSpacecraft(randomizer).ToSpaceship();

        spacecraft.OwnerId = 1;
        spacecraft.PositionX = 1000;
        spacecraft.PositionY = 1000;
        spacecraft.Speed = 10;
        spacecraft.Direction = 0;
        spacecraft.Agility = 1;
        spacecraft.MaxSpeed = 20;

        return spacecraft;
    }
}
