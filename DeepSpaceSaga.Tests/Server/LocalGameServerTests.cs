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

        var isRunningSessionAfterResume = !_gameServer.GetSession().State.IsPaused;

        _gameServer.PauseSession();

        var isRunningSessionAfterPause = !_gameServer.GetSession().State.IsPaused;

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
        var expectedStep4 = 4;

        // Act
        var _gameServer = Generator.LocalGameServer();

        var step1 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(2);

        var step2 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(3);

        var step3 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(4);

        var step4 = _gameServer.SessionContext.Session.State.Speed;

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

        _gameServer.SetGameSpeed(3);

        var step1 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(2);

        var step2 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(1);

        var step3 = _gameServer.SessionContext.Session.State.Speed;

        _gameServer.SetGameSpeed(1);

        var step4 = _gameServer.SessionContext.Session.State.Speed;

        // Assert
        Assert.Equal(expectedStep1, step1);
        Assert.Equal(expectedStep2, step2);
        Assert.Equal(expectedStep3, step3);
        Assert.Equal(expectedStep4, step4);
    }
}
