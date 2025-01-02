namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingModulesEnablingHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    private IFlowContext Handle(IFlowContext sessionContext)
    {
        if (sessionContext == null)
            throw new ArgumentNullException(nameof(sessionContext));

        foreach (Command command in sessionContext.EventsSystem.Commands.Where(x => x.Status == CommandStatus.PreProcess))
        {
            command.Status = CommandStatus.Process;

            var module = sessionContext.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);
            if (module == null)
            {
                continue;
            }

            if (command.IsOneTimeCommand == false)
            {
                module.Reload(sessionContext.Settings.RatePerSecond());
            }
        }

        return sessionContext;
    }
}

public static class PreProcessingModulesEnablingHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesEnabling(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PreProcessingModulesEnablingHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesEnabling(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PreProcessingModulesEnablingHandler>(result);
    }
}
