namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingCommandCleanerHandler : BaseHandler, ICalculationHandler
{
    /// <summary>
    /// Defines the order of handler execution
    /// </summary>
    public int Order => int.MaxValue;

    /// <summary>
    /// Type of the handler
    /// </summary>
    public HandlerType Type => HandlerType.PostProcessing;

    /// <summary>
    /// Processes the session context
    /// </summary>
    /// <param name="context">Session context</param>
    /// <returns>Processed session context</returns>
    public SessionContext Handle(SessionContext context)
    {
        var finishedCommands = FinishedCommands(context.EventsSystem);

        foreach (var command in finishedCommands) 
        { 
            if(command.ModuleId > 0)
            {
                if (command.Category == CommandCategory.Mining)
                {
                    var x = "";
                }

                var celestialObjectId = context.Session.GetCelestialObject(command.CelestialObjectId);

                if(celestialObjectId is ISpacecraft spacecraft)
                {
                    var module = spacecraft.GetModule(command.ModuleId);

                    if(module != null)
                    {
                        module.IsActive = false;
                    }
                }                
            }
        }

        context.EventsSystem = RemoveFinishedCommands(context.EventsSystem);
        return context;
    }

    /// <summary>
    /// Removes all commands with PostProcess status from the events system
    /// </summary>
    /// <param name="eventsSystem">Game events system</param>
    /// <returns>Updated game events system</returns>
    internal GameEventsSystem RemoveFinishedCommands(GameEventsSystem eventsSystem)
    {
        eventsSystem.Commands = new ConcurrentQueue<Command>(
            eventsSystem.Commands.Where(cmd => cmd.Status != CommandStatus.PostProcess));
            
        return eventsSystem;
    }

    internal ConcurrentQueue<Command> FinishedCommands(GameEventsSystem eventsSystem)
    {
        var result = new ConcurrentQueue<Command>(
            eventsSystem.Commands.Where(cmd => cmd.Status == CommandStatus.PostProcess));

        return result;
    }
}
