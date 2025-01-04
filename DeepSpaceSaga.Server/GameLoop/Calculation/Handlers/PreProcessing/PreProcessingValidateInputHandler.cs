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

        // Clear UI events before turn calculation
        context.Session.Events = new GameActionEvents([]);

        return factory.CreateStep<PreProcessingValidateInputHandler>(context);
    }
}
