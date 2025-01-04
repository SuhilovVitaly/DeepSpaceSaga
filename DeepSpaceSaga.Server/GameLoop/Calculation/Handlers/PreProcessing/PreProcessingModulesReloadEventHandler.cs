namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingModulesReloadEventHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
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

        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        // Get current turn
        var currentTurn = sessionContext.Session.Metrics.TurnsTicks;

        // Skip processing if it's the first turn
        if (currentTurn <= 0) return sessionContext;

        // Get modules that were reloaded in current turn
        var reloadedModules = spacecraft.Modules.Where(module =>
            module.IsReloaded &&
            module.LastReloadTurn == currentTurn);

        foreach (var module in reloadedModules)
        {
            switch (module.Category)
            {
                case Category.Weapon:
                    break;
                case Category.Shield:
                    break;
                case Category.Propulsion:
                    break;
                case Category.Reactor:
                    break;
                case Category.SpaceScanner:
                    break;
                case Category.DeepScanner:
                    break;
                case Category.MiningLaser:
                    break;
                case Category.CargoUnit:
                    break;
                case Category.Ore:
                    break;
                default:
                    break;
            }

            sessionContext.EventsSystem.ProcessModuleResults(spacecraft, module);            
        }

        return sessionContext;
    }
}

public static class PreProcessingModulesReloadEventHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesReloadEvent(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PreProcessingModulesReloadEventHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingModulesReloadEvent(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PreProcessingModulesReloadEventHandler>(result);
    }
}
