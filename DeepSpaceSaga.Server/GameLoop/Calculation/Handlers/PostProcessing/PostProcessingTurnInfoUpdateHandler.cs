namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingTurnInfoUpdateHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        context.Session.Metrics.TurnsTicks++;
        context.Session.Metrics.TurnTick++;

        if(context.Session.Metrics.TurnTick >= 10)
        {
            context.Session.Metrics.TurnTick = 0;
            context.Session.Metrics.Turn++;
        }
        
        return context;
    }
}

public static class PostProcessingTurnInfoUpdateHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> PostProcessingTurnInfoUpdate(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<PostProcessingTurnInfoUpdateHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> PostProcessingTurnInfoUpdate(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<PostProcessingTurnInfoUpdateHandler>(result);
    }
}
