namespace DeepSpaceSaga.Server.GameLoop.Flow;

public static partial class FlowExtensions
{  
    public static IFlowStep<IFlowContext, IFlowContext> ValidateInput(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingLocationsHandler>(context);
    }
}
