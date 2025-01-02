namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingCommandCleanerHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        var finishedCommands = FinishedCommands(context.EventsSystem);

        foreach (var command in finishedCommands) 
        { 
            if(command.ModuleId > 0)
            {
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
        eventsSystem.Commands = new ConcurrentQueue<ICommand>(
            eventsSystem.Commands.Where(cmd => cmd.Status != CommandStatus.PostProcess));
            
        return eventsSystem;
    }

    internal ConcurrentQueue<ICommand> FinishedCommands(GameEventsSystem eventsSystem)
    {
        var result = new ConcurrentQueue<ICommand>(
            eventsSystem.Commands.Where(cmd => cmd.Status == CommandStatus.PostProcess));

        return result;
    }
}

public static class PostProcessingCommandCleanerHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PostProcessingCommandCleaner(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PostProcessingCommandCleanerHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PostProcessingCommandCleaner(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PostProcessingCommandCleanerHandler>(result);
    }
}