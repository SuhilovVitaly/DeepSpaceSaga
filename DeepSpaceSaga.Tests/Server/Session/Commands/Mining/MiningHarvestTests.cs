namespace DeepSpaceSaga.Tests.Server.Session.Commands.Mining;

public class MiningHarvestTests
{
    [Fact]
    public void BaseHarvestOperationByMiningLaser_ShouldWorkCorrect()
    {
        // Arrange
        var generationTool = new GenerationTool();

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 0;
        spacecraft.Agility = 1;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(generationTool, 35, 1010, 1010, 8, "ASR-CS-541");
        asteroid.Id = 2000;
        asteroid.Speed = 0;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        var miningLaser = spacecraft.GetModules(Category.MiningLaser).FirstOrDefault() as IMiningLaser;
        var command = miningLaser.Harvest(asteroid.Id);
        command.Id = generationTool.GetId();

        _gameServer?.AddCommand(command);

        session.State.SetSpeed(1);

        var commandPreProcessingStatus = _gameServer.SessionContext.EventsSystem.GetCommand(command.Id).Status;

        _gameServer?.Execution();

        var commandProcessingStatus = _gameServer.SessionContext.EventsSystem.GetCommand(command.Id).Status;

        _gameServer?.Execution();

        session.State.SetSpeed(10);

        // 10 seconds execution
        for(int i = 0; i < 15; i++)
        {
            _gameServer?.Execution();
        }

        var commandCount = _gameServer.SessionContext.EventsSystem.Commands.Where(x => x.Category == CommandCategory.Mining).Count();

        // Assert
        Assert.Equal(CommandStatus.PreProcess, commandPreProcessingStatus);
        Assert.Equal(CommandStatus.Process, commandProcessingStatus);
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingMiningCommandFinished));
        Assert.Equal(0, commandCount);
    }

    [Fact]
    public void BaseHarvestOperationByMiningLaserWithToBigDistance_ShouldBeCancelled()
    {
        // Arrange
        var generationTool = new GenerationTool();

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 0;
        spacecraft.Agility = 1;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(generationTool, 35, 1210, 1210, 8, "ASR-CS-541");
        asteroid.Id = 2000;
        asteroid.Speed = 0;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        var miningLaser = spacecraft.GetModules(Category.MiningLaser).FirstOrDefault() as IMiningLaser;
        var command = miningLaser.Harvest(asteroid.Id);
        command.Id = generationTool.GetId();

        _gameServer?.AddCommand(command);

        session.State.SetSpeed(1);

        var commandPreProcessingStatus = _gameServer.SessionContext.EventsSystem.GetCommand(command.Id)?.Status;

        _gameServer?.Execution();

        var commandProcessingStatus = _gameServer.SessionContext.EventsSystem.GetCommand(command.Id)?.Status;

        // Assert
        Assert.Equal(CommandStatus.PreProcess, commandPreProcessingStatus);
        Assert.Null(commandProcessingStatus);
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingMiningCommandCancelled));
    }
}
