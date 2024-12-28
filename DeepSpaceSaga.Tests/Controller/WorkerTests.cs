using DeepSpaceSaga.Common.Infrastructure.Commands;
using DeepSpaceSaga.Controller;

namespace DeepSpaceSaga.Tests.Controller;

public class WorkerTests : IDisposable
{
    private readonly Mock<IGameServer> _gameServerMock;
    private readonly Worker _worker;
    private readonly GameSession _testSession;

    public WorkerTests()
    {
        _gameServerMock = new Mock<IGameServer>();
        _testSession = new GameSession(new CelestialMap([])); 
        _gameServerMock.Setup(x => x.GetSession()).Returns(_testSession);
        _worker = new Worker(_gameServerMock.Object);
    }

    [Fact]
    public async Task SendCommandAsync_ShouldCallGameServerAddCommand()
    {
        // Arrange
        var command = new Command();

        // Act
        await _worker.SendCommandAsync(command);

        // Assert
        _gameServerMock.Verify(x => x.AddCommand(command));
    }

    [Fact]
    public void SetGameSpeed_WhenGameIsPaused_ShouldResumeSession()
    {
        // Arrange
        _testSession.State.IsPaused = true;

        // Act
        _worker.SetGameSpeed(2);

        // Assert
        _gameServerMock.Verify(x => x.SetGameSpeed(2));
        _gameServerMock.Verify(x => x.ResumeSession());
    }

    [Fact]
    public void Resume_ShouldCallGameServerResumeSession()
    {
        // Act
        _worker.Resume();

        // Assert
        _gameServerMock.Verify(x => x.ResumeSession());
    }

    [Fact]
    public void Pause_ShouldCallGameServerPauseSession()
    {
        // Act
        _worker.Pause();

        // Assert
        _gameServerMock.Verify(x => x.PauseSession());
    }

    [Fact]
    public async Task SendCommandAsync_WhenCancelled_ShouldThrowOperationCanceledException()
    {
        // Arrange
        var command = new Command();
        var cts = new CancellationTokenSource();
        _gameServerMock
            .Setup(x => x.AddCommand(It.IsAny<Command>()))
            .ThrowsAsync(new OperationCanceledException());

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(
            () => _worker.SendCommandAsync(command, cts.Token));
    }

    public void Dispose()
    {
        // Cleanup code if needed
    }
}