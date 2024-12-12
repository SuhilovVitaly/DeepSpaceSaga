using DeepSpaceSaga.Common.Settings;

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
        var _gameServer = new LocalGameServer(session, new ServerMetrics());

        return _gameServer;
    }

    public static GameSessionsSettings TestsSessionsSettings()
    {
        return new GameSessionsSettings
        {
            AsteroidGenerationRatio = 1000
        };
    }

    public static ISpacecraft SpacecraftWithModules()
    {
        var spacecraft = new BaseSpaceship
        {
            Id = new GenerationTool().GetId(),
            OwnerId = 1,
            PositionX = 1000,
            PositionY = 1000,
            Speed = 10,
            Direction = 0,
            Agility = 1,
            MaxSpeed = 20,
            Types = CelestialObjectTypes.SpaceshipPlayer
        };

        spacecraft.Modules.Add(PropulsionModulesGenerator.CreateMicroWarpDrive(spacecraft.Id, "PMV5002"));
        spacecraft.Modules.Add(GeneralModuleGenerator.CreateSpaceScanner(spacecraft.Id, "SCR5001"));

        return spacecraft;
    }
}
