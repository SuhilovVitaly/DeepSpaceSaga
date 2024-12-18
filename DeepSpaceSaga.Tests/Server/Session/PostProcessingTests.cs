namespace DeepSpaceSaga.Tests.Server.Session;

public class PostProcessingTests
{
    private readonly IServerMetrics _metricsMock;

    public PostProcessingTests()
    {
        _metricsMock = new ServerMetrics();
    }

    [Fact]
    public void RemoveFinishedCommands_ShouldRemovePostProcessCommands()
    {
        // Arrange
        var postProcessing = new PostProcessing();
        var eventsSystem = new GameEventsSystem(_metricsMock);

        var command1 = new Command { Status = CommandStatus.PostProcess };
        var command2 = new Command { Status = CommandStatus.PreProcess };
        var command3 = new Command { Status = CommandStatus.Process };

        eventsSystem.AddCommand(command1);
        eventsSystem.AddCommand(command2);
        eventsSystem.AddCommand(command3);

        // Act
        var result = postProcessing.RemovefinishedCommands(eventsSystem);

        // Assert
        result.Commands.Count.Should().Be(2);
        result.Commands.Should().NotContain(x => x.Status == CommandStatus.PostProcess);
    }

    [Fact]
    public void Run_ShouldProcessCommandsAndUpdateContext()
    {
        // Arrange
        var postProcessing = new PostProcessing();
        var session = new GameSession(new CelestialMap([]));
        var eventsSystem = new GameEventsSystem(_metricsMock);
        var sessionContext = new SessionContext(session, eventsSystem, new ServerMetrics());

        var command1 = new Command { Status = CommandStatus.PostProcess };
        var command2 = new Command { Status = CommandStatus.Process };

        eventsSystem.AddCommand(command1);
        eventsSystem.AddCommand(command2);

        // Act
        var result = postProcessing.Run(sessionContext);

        // Assert
        result.EventsSystem.Commands.Count.Should().Be(1);
        result.EventsSystem.Commands.Should().NotContain(x => x.Status == CommandStatus.PostProcess);
    }

    [Fact]
    public void Execute_ShouldReturnProcessedContext()
    {
        // Arrange
        var session = new GameSession(new CelestialMap([]));
        var eventsSystem = new GameEventsSystem(_metricsMock);
        var sessionContext = new SessionContext ( session, eventsSystem, new ServerMetrics() );

        var command1 = new Command { Status = CommandStatus.PostProcess };
        var command2 = new Command { Status = CommandStatus.Process };

        eventsSystem.AddCommand(command1);
        eventsSystem.AddCommand(command2);

        // Act
        var result = PostProcessing.Execute(sessionContext);

        // Assert
        result.EventsSystem.Commands.Count.Should().Be(1);
        result.EventsSystem.Commands.Should().NotContain(x => x.Status == CommandStatus.PostProcess);
    }
}
