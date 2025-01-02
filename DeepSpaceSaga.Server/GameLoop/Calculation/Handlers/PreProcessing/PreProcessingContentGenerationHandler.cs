namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

/// <summary>
/// Handler for pre-processing content generation
/// </summary>
public class PreProcessingContentGenerationHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = GenerateAsteroidsAction.Execute(flowContext);
        return flowContext;
    }
}

public static class PreProcessingContentGenerationHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingContentGeneration(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PreProcessingContentGenerationHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingContentGeneration(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PreProcessingContentGenerationHandler>(result);
    }
}
