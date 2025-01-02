namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingCommandCleanerHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.GetCommandsByStatus(CommandStatus.Process))
        {
            var module = context.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if (module is null || module.IsCalculated || command.IsOneTimeCommand)
            {
                command.Status = CommandStatus.PostProcess;
            }
        }

        return context;
    }
}

public static class ProcessingCommandCleanerHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingCommandCleaner(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingCommandCleanerHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingCommandCleaner(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingCommandCleanerHandler>(result);
    }
}
