namespace DeepSpaceSaga.Tests.Server;

public class LocalGameServerTests
{
    [Fact]
    public void GameServer_WithPauseAndResumeGame_ShouldWorkCorrect()
    {
        // Arrange
        var expectedIsSessionRunning = false; 

        // Act
        var _gameServer = Generator.LocalGameServer();

        _gameServer.ResumeSession();

        var isRunningSessionAfterResume = _gameServer.GetSession().IsRunning;

        _gameServer.PauseSession();

        var isRunningSessionAfterPause = _gameServer.GetSession().IsRunning;

        // Assert
        Assert.Equal(expectedIsSessionRunning, isRunningSessionAfterPause);
        Assert.NotEqual(isRunningSessionAfterResume, isRunningSessionAfterPause);
    }

    [Fact]
    public void GameServer_IncreaseGameSpeed_ShouldWorkCorrect()
    {
        // Arrange
        var expectedStep1 = 1;
        var expectedStep2 = 2;
        var expectedStep3 = 3;
        var expectedStep4 = 3;

        // Act
        var _gameServer = Generator.LocalGameServer();

        var step1 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.IncreaseGameSpeed();

        var step2 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.IncreaseGameSpeed();

        var step3 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.IncreaseGameSpeed();

        var step4 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.IncreaseGameSpeed();

        // Assert
        Assert.Equal(expectedStep1, step1);
        Assert.Equal(expectedStep2, step2);
        Assert.Equal(expectedStep3, step3);
        Assert.Equal(expectedStep4, step4);
    }

    [Fact]
    public void GameServer_DecreaseGameSpeed_ShouldWorkCorrect()
    {
        // Arrange
        var expectedStep1 = 3;
        var expectedStep2 = 2;
        var expectedStep3 = 1;
        var expectedStep4 = 1;

        // Act
        var _gameServer = Generator.LocalGameServer();

        _gameServer.IncreaseGameSpeed();
        _gameServer.IncreaseGameSpeed();

        var step1 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.DecreaseGameSpeed();

        var step2 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.DecreaseGameSpeed();

        var step3 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.DecreaseGameSpeed();

        var step4 = _gameServer.SessionContext.Session.Speed.Speed;

        _gameServer.DecreaseGameSpeed();

        // Assert
        Assert.Equal(expectedStep1, step1);
        Assert.Equal(expectedStep2, step2);
        Assert.Equal(expectedStep3, step3);
        Assert.Equal(expectedStep4, step4);
    }
}
