namespace DeepSpaceSaga.Tests.Server.Session.Commands;

public class NavigationCommandsProcessingTests
{
    [Fact]
    public void TurnLeft_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedDirection = 359;

        // Act
        var session = new GameSession(new CelestialMap([]), new GameSessionsSettings());

        var spacecraft = Generator.SpacecraftWithModules();        

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.TurnLeft,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedDirection, spacecraftAfterCalculateCommand.Direction);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand)); 
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationTurnLeftCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void TurnRight_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedDirection = 1;

        // Act
        var session = new GameSession(new CelestialMap([]), new GameSessionsSettings());

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.TurnRight,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedDirection, spacecraftAfterCalculateCommand.Direction);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationTurnRightCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void IncreaseShipSpeed_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 10.5;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.IncreaseShipSpeed,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationIncreaseShipSpeedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void IncreaseShipSpeed_WithNormalGameSpeed_CantIncreaseSpeed()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 10;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.MaxSpeed = 10;

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.IncreaseShipSpeed,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationIncreaseShipSpeedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void DecreaseShipSpeed_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 9.5;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.DecreaseShipSpeed,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationDecreaseShipSpeedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void DecreaseShipSpeed_WithNormalGameSpeed_CantDecreaseSpeed()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 0;

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 0;

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.DecreaseShipSpeed,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationDecreaseShipSpeedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }
}
