namespace DeepSpaceSaga.Tests.Server.Session;

public class BasicGameFlowTests
{
    [Fact]
    public void GameSession_StartedBaseScenario_ShouldBeCorrect()
    {
        // Arrange
        int expectedTurn = 1;
        string expectedSpacecraftName = "Glowworm";
        int expectedCelestialObjects = 3;
        int expectedOwnerId = 1;

        // Act
        var _gameServer = Generator.LocalGameServer();
        var session = _gameServer.GetSession();
        var spaceMap = session.SpaceMap;
        ISpacecraft? spacecraft = spaceMap.GetCelestialObjects()[0] as ISpacecraft;

        // Assert
        Assert.Equal(expectedTurn, session.Turn);
        Assert.Equal(expectedCelestialObjects, spaceMap.GetCelestialObjects().Count);
        Assert.Equal(expectedSpacecraftName, spacecraft?.Name);
        Assert.Equal(expectedOwnerId, spacecraft?.OwnerId);
    }

    [Fact]
    public void GameSession_PauseAndResume_ShouldWorkCorrect()
    {
        // Arrange
        bool expectedTurnFirstSessionStatus = false;
        bool expectedTurnSecondSessionStatus = true;
        bool expectedTurnThirdSessionStatus = false;
        int expectedSessionId = -1;

        // Act
        var _gameServer = new LocalGameServer();
        _gameServer.SessionInitialization(expectedSessionId);

        var turnFirstSessionStatus = _gameServer.GetSession().IsRunning;

        _gameServer.ResumeSession();

        var turnSecondSessionStatus = _gameServer.GetSession().IsRunning;

        _gameServer.PauseSession();

        var turnThirdSessionStatus = _gameServer.GetSession().IsRunning;

        // Assert
        Assert.Equal(expectedTurnFirstSessionStatus, turnFirstSessionStatus);
        Assert.Equal(expectedTurnSecondSessionStatus, turnSecondSessionStatus);
        Assert.Equal(expectedTurnThirdSessionStatus, turnThirdSessionStatus);
        Assert.Equal(expectedSessionId, _gameServer.GetSession().Id);
    }

    [Fact]
    public void GameSession_AddingNewCelestialObject_ShouldWorkCorrect()
    {
        // Arrange
        int expectedCelestialObjectsAfterInitialization = 0;
        int expectedCelestialObjectsAfterAddNewAsteroid = 1;

        // Act
        var session = new GameSession(new CelestialMap(new List<ICelestialObject>()));

        var celestialObjectsAfterInitialization = session.SpaceMap.Count;

        session.SpaceMap.Add(AsteroidGenerator.CreateAsteroid(35, 10010, 10010, 3, "ASR-CS-541"));

        var celestialObjectsAfterAddNewAsteroid = session.SpaceMap.Count;

        // Assert
        Assert.Equal(expectedCelestialObjectsAfterInitialization, celestialObjectsAfterInitialization);
        Assert.Equal(expectedCelestialObjectsAfterAddNewAsteroid, celestialObjectsAfterAddNewAsteroid);
    }

    [Fact]
    public void GameSession_BasicNavigationCalculators_ShouldBeCorrect()
    {
        // Arrange
        double expectedStartPositionX = 10000;

        // Act
        var _gameServer = Generator.LocalGameServer();
        double startPositionX = (_gameServer.GetSession().SpaceMap.GetCelestialObjects()[0] as ISpacecraft).PositionX;

        _gameServer.Execution(1);

        double afterCalculationPositionX = (_gameServer.GetSession().SpaceMap.GetCelestialObjects()[0] as ISpacecraft).PositionX;

        // Assert
        Assert.Equal(expectedStartPositionX, startPositionX);
        Assert.NotEqual(expectedStartPositionX, afterCalculationPositionX);
    }
}
