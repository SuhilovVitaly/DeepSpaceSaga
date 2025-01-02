namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingValidateInputHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {        
        // TODO: Validate context
        return flowContext;
    }

}

public static class PreProcessingValidateInputFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PreProcessingValidateInput(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PreProcessingValidateInputHandler>(context);
    }
}
