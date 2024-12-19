namespace DeepSpaceSaga.Server.Infrastructure;

public class GameEventsSystem(IServerMetrics metrics)
{
    public ConcurrentQueue<Command> Commands { get; set; } = new();
    public ConcurrentDictionary<long, GameActionEvent> Actions { get; set; } = [];

    public GameEventsSystem Clone()
    {
        var duplicate = new GameEventsSystem(metrics)
        {
            Commands = new ConcurrentQueue<Command>(),
            Actions = new ConcurrentDictionary<long, GameActionEvent>()
        };

        foreach (var command in Commands)
        {
            duplicate.Commands.Enqueue(command.Copy());
        }

        foreach (var action in Actions)
        {
            duplicate.Actions.TryAdd(action.Key, action.Value.Copy());
        }

        return duplicate;
    }

    public void EndTurnProcessing()
    {
        Commands = new ConcurrentQueue<Command>();
    }

    public void AddCommand(Command command)
    {
        ArgumentNullException.ThrowIfNull(command);

        metrics.Add(Metrics.ReceivedCommand);
        Commands.Enqueue(command);
    }

    public Command? GetCommand(int commandId)
    {
        return Commands?.Where(x => x.Id == commandId).FirstOrDefault();
    }

    public void ProcessModuleResults(ICelestialObject spacecraft, IModule module)
    {
        ArgumentNullException.ThrowIfNull(spacecraft);
        ArgumentNullException.ThrowIfNull(module);

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
