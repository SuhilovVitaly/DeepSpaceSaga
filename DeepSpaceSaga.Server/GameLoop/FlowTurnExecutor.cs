namespace DeepSpaceSaga.Server.GameLoop;

public class FlowTurnExecutor
{
    public static IFlowContext Execute(IFlowContext context)
    {
        var sessionContext = new SessionContext(
            context.Session.Copy(),
            context.EventsSystem.Clone(),
            context.Metrics,
            context.Randomizer,
            context.Settings);


        var flowManager = new FlowManager<SessionContext>(FlowStepFactory.Instance, sessionContext);

        var result = flowManager
            .Initialize()
            // ---------------------------------------------- Pre Processing flow
            .PreProcessingValidateInput()
            .PreProcessingContentGeneration()
            .PreProcessingModulesEnabling()
            .PreProcessingModulesReloading()
            .PreProcessingModulesReloadEvent()
            .PreProcessingScan()
            // ---------------------------------------------- Processing flow
            .ProcessingLocations()     
            .ProcessingItemsTransfer()
            .ProcessingContentGeneration()
            .ProcessingMiningOperations()
            .ProcessingModuleActivation()
            .ProcessingNavigation()
            .ProcessingScan()
            .ProcessingCommandCleaner()
            // ---------------------------------------------- Post Processing flow
            .PostProcessingTurnInfoUpdate()
            .PostProcessingCommandCleaner()
            .PostProcessingFinishFlow();

        return result.FlowContext;

    }
}
