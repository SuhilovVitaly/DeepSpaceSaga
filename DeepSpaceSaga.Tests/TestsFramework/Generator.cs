namespace DeepSpaceSaga.Tests.TestsFramework;

internal class Generator
{
    public static LocalGameServer LocalGameServer()
    {
        var _gameServer = new LocalGameServer();
        _gameServer.SessionInitialization();

        return _gameServer;
    }

    public static LocalGameServer LocalGameServerWithPreSetSessoin(GameSession session)
    {
        var _gameServer = new LocalGameServer(session);

        return _gameServer;
    }

    public static ISpacecraft Spacecraft()
    {
        return new BaseSpaceship
        {
            Id = new GenerationTool().GetId(),
            OwnerId = 1,
            PositionX = 1000,
            PositionY = 1000,
            Speed = 10,
            Direction = 0,
            Types = CelestialObjectTypes.SpaceshipPlayer
        };
    }
}
