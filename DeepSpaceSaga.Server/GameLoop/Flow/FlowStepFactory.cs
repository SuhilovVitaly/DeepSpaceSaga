namespace DeepSpaceSaga.Server.GameLoop.Flow;

public class FlowStepFactory
{
    public static FlowStepFactory Instance { get; } = new FlowStepFactory();

    private readonly Dictionary<Type, Type> _steps = new();

    public void RegisterStep<TStep, TIn, TOut>()
        where TStep : IFlowStep<TIn, TOut>
        where TIn : IFlowContext
        where TOut : IFlowContext
    {
        _steps[typeof(TStep)] = typeof(TStep);
    }

    public TStep CreateStep<TStep>(IFlowContext context)
        where TStep : IFlowStep<IFlowContext, IFlowContext>
    {
        var type = typeof(TStep);
        if (!_steps.ContainsKey(type))
            throw new ArgumentException($"Step {type.Name} is not registered");

        return (TStep)Activator.CreateInstance(type, context)!;
    }

    // Initialize all flow steps
    public FlowStepFactory()
    {
        RegisterStep<ProcessingLocationsHandler, IFlowContext, IFlowContext>();
        RegisterStep<PreProcessingValidateInputHandler, IFlowContext, IFlowContext>();
        RegisterStep<PreProcessingContentGenerationHandler, IFlowContext, IFlowContext>();
        RegisterStep<PreProcessingModulesEnablingHandler, IFlowContext, IFlowContext>();
        RegisterStep<PreProcessingModulesReloadingHandler, IFlowContext, IFlowContext>();
        RegisterStep<PreProcessingScanHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingCommandCleanerHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingContentGenerationHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingMiningOperationsHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingModuleActivationHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingNavigationHandler, IFlowContext, IFlowContext>();
        RegisterStep<ProcessingScanHandler, IFlowContext, IFlowContext>();
        RegisterStep<PostProcessingTurnInfoUpdateHandler, IFlowContext, IFlowContext>();
        RegisterStep<PostProcessingCommandCleanerHandler, IFlowContext, IFlowContext>();
        RegisterStep<PostProcessingFinishFlowStage, IFlowContext, IFlowContext>();
    }
}
