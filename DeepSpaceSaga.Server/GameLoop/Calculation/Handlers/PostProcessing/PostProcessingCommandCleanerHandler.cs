namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingCommandCleanerHandler : BaseHandler, ICalculationHandler
{
    public int Order => int.MaxValue;

    public HandlerType Type => HandlerType.PostProcessing;

    public SessionContext Handle(SessionContext context)
    {
        context.EventsSystem = RemovefinishedCommands(context.EventsSystem);

        return context;
    }

    internal GameEventsSystem RemovefinishedCommands(GameEventsSystem eventsSystem)
    {
        var filteredCommands = new ConcurrentQueue<Command>();

        foreach (var command in eventsSystem.Commands)
        {
            if (command.Status != CommandStatus.PostProcess)
            {
                filteredCommands.Enqueue(command);
            }
        }

        eventsSystem.Commands = filteredCommands;

        return eventsSystem;
    }
}
