namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingModulesReloadingHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext sessionContext)
    {
        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        foreach (var moudle in spacecraft.Modules)
        {
            if (moudle.IsReloaded == false)
            {
                moudle.Reload(sessionContext.Settings.RatePerSecond());

                if (moudle.IsReloaded)
                {
                    sessionContext.EventsSystem.ProcessModuleResults(spacecraft, moudle);
                }
            }
        }

        return sessionContext;
    }
}

public static class PreProcessingModulesReloadingHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesReloading(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PreProcessingModulesReloadingHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesReloading(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PreProcessingModulesReloadingHandler>(result);
    }
}
