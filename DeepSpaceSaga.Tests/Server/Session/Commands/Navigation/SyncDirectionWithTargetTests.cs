using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Tests.Server.Session.Commands.Navigation;

public class SyncDirectionWithTargetTests
{
    [Theory]
    [InlineData(36, 1)]
    [InlineData(34, 1)]
    public void SyncDirectionWithTargetCommand_WithExistTarget_ShouldWorkCorrect(double spacecraftDirection, double expectedExecutionCycles)
    {
        // Arrange
        double expectedReceivedCommand = 1;
        double startSpacecrafeSpeed = 2;
        var generationTool = new GenerationTool();

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = startSpacecrafeSpeed;
        spacecraft.Agility = 1;
        spacecraft.Direction = spacecraftDirection;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(generationTool, 35, 10010, 10010, 8, "ASR-CS-541");
        asteroid.Id = 2000;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncDirectionWithTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = asteroid.Id,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.Module(Category.Propulsion).Id
        });

        session.State.SetSpeed(1);

        _gameServer?.Execution();

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        // Assert 
        Assert.Equal(spacecraftAfterCalculateCommand.Direction, asteroid.Direction);
        Assert.Equal(expectedReceivedCommand, _gameServer.Metrics.Get(Metrics.ReceivedCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationCommand));
        Assert.Equal(expectedExecutionCycles, _gameServer.Metrics.Get(Metrics.ProcessingNavigationSyncDirectionWithTargetCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingNavigationSyncDirectionWithTargetCommandFinished));
        //Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
        Assert.Equal(0, _gameServer.SessionContext.EventsSystem.Commands.Count);
    }
}
