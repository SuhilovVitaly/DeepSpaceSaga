using DeepSpaceSaga.Server;

namespace DeepSpaceSaga.Tests.Server.Session.Commands;

public class GenerateCelestialObjectTests
{
    [Fact]
    public void LocalGameServer_AddCommandWithAsteroidGeneration_ShouldBeCorrect()
    {
        // Arrange
        int expectedCelestialObjects = 1;
        int expectedCelestialObjectsAfterCommandExecute = 2;

        // Act
        var settings = new GameSessionsSettings { AsteroidGenerationRatio = 0 };
        var session = new GameSession(new CelestialMap([]), settings);

        var spacecraft = Generator.SpacecraftWithModules();

        session.SpaceMap.Add(spacecraft);

        var _gameServer = Generator.LocalGameServerWithPreSetSessoin(session);

        var celestialObjects = _gameServer.GetSession().SpaceMap.Count;

        _gameServer.Execution();

        var celestialObjectsAfterCommandExecute = _gameServer.GetSession().SpaceMap.Count;

        // Assert
        Assert.Equal(expectedCelestialObjects, celestialObjects);
        Assert.Equal(expectedCelestialObjectsAfterCommandExecute, celestialObjectsAfterCommandExecute);
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.PreProcessingGenerateNewAsteroidCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.ProcessingGenerateAsteroidCommand));
        Assert.Equal(1, _gameServer.Metrics.Get(Metrics.MessageAddedToJournal));
    }
}
