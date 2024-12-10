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

    [Fact]
    public void FullStop_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 0;

        // Act
        var session = new GameSession(new CelestialMap([]), Generator.TestsSessionsSettings());

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.StopShip,
            Status = CommandStatus.Process,
            IsOneTimeCommand = false,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        _gameServer?.Execution(20);

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(20, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(20, _gameServer.Metrics.Get(Metrics.ProcessingNavigationStopShipCommand));
        //Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void FullSpeed_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double expectedSpeed = 20;

        // Act
        var session = new GameSession(new CelestialMap([]), Generator.TestsSessionsSettings());

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.FullSpeed,
            Status = CommandStatus.Process,
            IsOneTimeCommand = false,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution();

        _gameServer?.Execution(20);

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(20, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(20, _gameServer.Metrics.Get(Metrics.ProcessingNavigationFullSpeedCommand));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }

    [Fact]
    public void MultyCommand_WithNormalGameSpeed_ShouldBeCorrect()
    {
        // Arrange
        double expectedReceivedCommand = 2;
        double expectedDirection = 359;
        double expectedSpeed = 20;

        // Act
        var session = new GameSession(new CelestialMap([]), Generator.TestsSessionsSettings());

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.FullSpeed,
            Status = CommandStatus.Process,
            IsOneTimeCommand = false,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution(5);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.TurnLeft,
            Status = CommandStatus.Process,
            IsOneTimeCommand = true,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
        });

        _gameServer?.Execution(20);

        var spacecraftAfterCalculateCommand = _gameServer?.GetSession().GetPlayerSpaceShip();

        // Assert
        Assert.Equal(expectedSpeed, spacecraftAfterCalculateCommand.Speed);
        Assert.Equal(expectedDirection, spacecraftAfterCalculateCommand.Direction);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(21, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(20, _gameServer.Metrics.Get(Metrics.ProcessingNavigationFullSpeedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationTurnLeftCommand));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }
}
