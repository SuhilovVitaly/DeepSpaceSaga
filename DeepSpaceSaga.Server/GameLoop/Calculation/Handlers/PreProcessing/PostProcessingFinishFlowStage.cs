namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PostProcessingFinishFlowStage(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        // TODO: Finish context update
        return context;
    }

}

public static class FinishFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PostProcessingFinishFlow(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PostProcessingFinishFlowStage>(result);
    }
}
