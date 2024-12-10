namespace DeepSpaceSaga.Server.Calculation;

public class GameEventsSystem(IServerMetrics metrics)
{
    private IServerMetrics metrics = metrics;

    public ConcurrentBag<Command> Commands { get; set; } = [];
    public ConcurrentDictionary<long, GameActionEvent> Actions { get; set; } = [];

    public GameEventsSystem Clone()
    {
        var duplicate = new GameEventsSystem(metrics)
        {
            Commands = new ConcurrentBag<Command>(),
            Actions = new ConcurrentDictionary<long, GameActionEvent>()
        };

        foreach (var command in Commands)
        {
            duplicate.Commands.Add(command.Copy());
        }

        foreach (var action in Actions)
        {
            duplicate.Actions.TryAdd(action.Key, action.Value.Copy());
        }

        return duplicate;
    }

    public void EndTurnProcessing()
    {
        Commands = [];
    }

    public void AddCommand(Command command)
    {
        metrics.Add(Metrics.ReceivedCommand);
        Commands.Add(command);
    }

    public void ProcessModuleResults(ICelestialObject spacecraft, IModule module)
    {
        var gameEvent = new GameActionEvent
        {
            Id = IdGenerator.GetNextId(),
            CelestialObjectId = spacecraft.Id,
            ModuleId = module.Id,
            TargetObjectId = module.TargetId
        };

        Actions.TryAdd(gameEvent.Id, gameEvent);
    }
}
