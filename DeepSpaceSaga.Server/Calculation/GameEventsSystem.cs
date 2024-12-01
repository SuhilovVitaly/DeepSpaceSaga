namespace DeepSpaceSaga.Server.Calculation;

public class GameEventsSystem
{
    public ConcurrentBag<Command> Commands { get; set; } = [];
    public ConcurrentDictionary<long, GameActionEvent> Actions { get; set; } = [];

    public void EndTurnProcessing()
    {
        Commands = [];
    }

    public void AddCommand(Command command)
    {
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
