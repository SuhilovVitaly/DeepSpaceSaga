namespace DeepSpaceSaga.Tests.Server.Session.Commands.Navigation;

public class SyncSpeedWithTargetTests
{
    [Fact]
    public void SyncSpeedWithTargetCommand_WithExistTarget_ShouldWorkCorrectForIncreaseSpeed()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 8;
        double startSpacecrafeSpeed = 2;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = startSpacecrafeSpeed;
        spacecraft.Agility = 1;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(35, 10010, 10010, 8, "ASR-CS-541");
        asteroid.Id = 2000;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = asteroid.Id,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        session.State.SetSpeed(10);

        _gameServer?.Execution();

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        var calculationCycles = (asteroid.Speed - startSpacecrafeSpeed) * 2 + 1;

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.ProcessingNavigationSyncSpeedWithTargetCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void SyncSpeedWithTargetCommand_WithExistTarget_ShouldWorkCorrectForDecreaseSpeed()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 8;
        double startSpacecrafeSpeed = 12;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = startSpacecrafeSpeed;
        spacecraft.Agility = 1;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(35, 10010, 10010, 8, "ASR-CS-541");
        asteroid.Id = 2000;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = asteroid.Id,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        session.State.SetSpeed(10);

        _gameServer?.Execution();

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        var calculationCycles = Math.Abs(asteroid.Speed - startSpacecrafeSpeed) * 2 + 1;

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.ProcessingNavigationSyncSpeedWithTargetCommand));
        Assert.Equal(calculationCycles, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void SyncSpeedWithTargetCommand_WithoutExistTarget_ShouldWorkCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 12;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 12;
        spacecraft.MaxSpeed = 14;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(35, 10010, 10010, 32, "ASR-CS-541");
        asteroid.Id = 2000;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = -1,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        session.State.SetSpeed(10);

        _gameServer?.Execution();

        session.State.SetSpeed(10);

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommandError));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void SyncSpeedWithTargetCommand_WithMoreFasterTarget_ShouldWorkCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 14;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 12;
        spacecraft.MaxSpeed = 14;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(35, 10010, 10010, 32, "ASR-CS-541");
        asteroid.Id = 2000;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = asteroid.Id,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        session.State.SetSpeed(10);

        _gameServer?.Execution();

        session.State.SetSpeed(10);

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(4, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(4, _gameServer.Metrics.Get(Metrics.ProcessingNavigationSyncSpeedWithTargetCommand));
        Assert.Equal(4, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }
}
