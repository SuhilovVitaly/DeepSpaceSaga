namespace DeepSpaceSaga.Tests.Server.Session.Commands;

public class GenerateCelestialObjectTests
{
    [Fact]
    public void LocalGameServer_AddCommandWithAsteroidGeneration_ShouldBeCorrect()
    {
        // Arrange
        int expectedCelestialObjects = 3;
        int expectedCelestialObjectsAfterCommandExecute = 4;

        // Act
        var _gameServer = Generator.LocalGameServer();
        var command = new Command
        { 
            Category = CommandCategory.ContentGeneration,
            Type = CommandTypes.GenerateAsteroid 
        };

        var celestialObjects = _gameServer.GetSession().SpaceMap.Count;

        _ = _gameServer.AddCommand(command);

        //_gameServer.EventsCalculation();

        var celestialObjectsAfterCommandExecute = _gameServer.GetSession().SpaceMap.Count;

        // Assert
        Assert.Equal(expectedCelestialObjects, celestialObjects);
        Assert.Equal(expectedCelestialObjectsAfterCommandExecute, celestialObjectsAfterCommandExecute);
    }
}
