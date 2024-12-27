namespace DeepSpaceSaga.Server.Infrastructure;

public class GameEventsSystem(IServerMetrics metrics, IGameActionEvents actions)
{
    public ConcurrentQueue<ICommand> Commands { get; set; } = new();
    public IGameActionEvents Actions { get; set; } = actions;
    private readonly GenerationTool _generationTool = new();

    public GameEventsSystem Clone()
    {
        var duplicate = new GameEventsSystem(metrics, actions)
        {
            Commands = new ConcurrentQueue<ICommand>(),
            Actions = Actions.Clone()
        };

        foreach (var command in Commands)
        {
            duplicate.Commands.Enqueue(command.Copy());
        }

        return duplicate;
    }

    public void EndTurnProcessing()
    {
        Commands = new ConcurrentQueue<ICommand>();
    }

    public void GenerateCommand(CommandTypes commandType, IModule module, ICelestialObject targetObject, ICelestialObject sourceObject)
    {
        AddCommand(CommandsFactory.CreateCommand(_generationTool, commandType, module, targetObject, sourceObject));
    }

    public void AddCommand(ICommand command)
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
        var result = new ConcurrentQueue<ICommand>();

        foreach (var command in Commands) 
        { 
            if(duplicateCommands.Contains(command.Id) == false)
            {
                result.Enqueue(command);
            }
        }

        Commands = result;
    }

    public ICommand? GetCommand(int commandId)
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
