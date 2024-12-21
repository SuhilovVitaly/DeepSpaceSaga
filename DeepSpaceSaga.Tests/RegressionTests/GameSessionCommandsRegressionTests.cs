namespace DeepSpaceSaga.Tests.RegressionTests;

public class GameSessionCommandsRegressionTests
{
    [Fact]
    public void DSS_69_Rotate_To_Target_ShouldWorkCorrect()
    {
        // Arrange
        double expectedDirection = 249;
        double startSpacecrafeSpeed = 2;
        var generationTool = new GenerationTool();

        // Act
        var session = new GameSession(new CelestialMap([]));

        var spacecraft = Generator.SpacecraftWithModules();
        spacecraft.Speed = 0;
        spacecraft.Direction = 269;
        spacecraft.Agility = 1;
        spacecraft.PositionX = 0;
        spacecraft.PositionY = 0;

        session.SpaceMap.Add(spacecraft);

        var asteroid = AsteroidGenerator.CreateAsteroid(generationTool, 35, 0, 10, 0, "ASR-CS-541");
        asteroid.Id = 2000;
        asteroid.Direction = 110;

        session.SpaceMap.Add(asteroid);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        _gameServer?.AddCommand(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.RotateToTarget,
            IsOneTimeCommand = false,
            TargetCelestialObjectId = asteroid.Id,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.GetModules(Category.Propulsion).FirstOrDefault().Id
        });

        session.State.SetSpeed(10);

        _gameServer?.Execution();

        _gameServer?.Execution();

        var spacecraftAfterCalculateCommand = _gameServer.GetSession().GetPlayerSpaceShip();

        var calculationCycles = (asteroid.Speed - startSpacecrafeSpeed) * 2 + 1;

        // Assert
        Assert.Equal(expectedDirection, spacecraftAfterCalculateCommand.Direction);
    }
}
