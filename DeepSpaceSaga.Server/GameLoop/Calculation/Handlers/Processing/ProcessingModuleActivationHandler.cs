namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingModuleActivationHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        var spacecraft = context.Session.GetPlayerSpaceShip();

        foreach (var module in spacecraft.Modules)
        {
            if(context.EventsSystem.Commands.Where(x=>x.ModuleId == module.Id && x.CelestialObjectId == spacecraft.Id).Any())
            {
                module.IsActive = true;

                if(module.Category == Category.MiningLaser)
                {
                    var x = "";
                }
            }
        }

        return context;
    }
}

public static class ProcessingModuleActivationHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingModuleActivation(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingModuleActivationHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingModuleActivation(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingModuleActivationHandler>(result);
    }
}
