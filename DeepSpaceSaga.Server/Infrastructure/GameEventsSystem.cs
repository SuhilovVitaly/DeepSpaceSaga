namespace DeepSpaceSaga.Server.Infrastructure;

public class GameEventsSystem(IServerMetrics metrics, IGameActionEvents actions)
{
    public ConcurrentQueue<Command> Commands { get; set; } = new();
    //public ConcurrentDictionary<long, GameActionEvent> Actions { get; set; } = [];
    public IGameActionEvents Actions { get; set; } = actions;
    private readonly GenerationTool _generationTool = new();

    public GameEventsSystem Clone()
    {
        var duplicate = new GameEventsSystem(metrics, actions)
        {
            Commands = new ConcurrentQueue<Command>(),
            Actions = Actions.Clone()
        };

        foreach (var command in Commands)
        {
            duplicate.Commands.Enqueue(command.Copy());
        }

        //foreach (var action in Actions)
        //{
        //    duplicate.Actions.TryAdd(action.Key, action.Value.Copy());
        //}

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

        if (command.IsUnique)
        {
            var existingCommandKeys = Commands
                .Where(cmd => cmd.Type == command.Type &&
                             cmd.CelestialObjectId == command.CelestialObjectId)
                .Select(cmd => cmd.Id)
                .ToList();

            if(existingCommandKeys.Count > 0)
            {
                RemoveDuplicateCommands(existingCommandKeys);
            }            
        }

        command.Id = _generationTool.GetId();

        Commands.Enqueue(command);
    }

    internal void RemoveDuplicateCommands(List<int> duplicateCommands)
    {
        var result = new ConcurrentQueue<Command>();

        foreach (var command in Commands) 
        { 
            if(duplicateCommands.Contains(command.Id) == false)
            {
                result.Enqueue(command);
            }
        }

        Commands = result;
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

        //Actions.TryAdd(gameEvent.Id, gameEvent);
    }
}
