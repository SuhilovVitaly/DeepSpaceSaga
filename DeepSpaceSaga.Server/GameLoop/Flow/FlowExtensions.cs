namespace DeepSpaceSaga.Server.GameLoop.Flow;

public static class FlowExtensions
{  
    public static IFlowStep<IFlowContext, IFlowContext> ValidateInput(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingLocationsHandler>(context);
    }
}
