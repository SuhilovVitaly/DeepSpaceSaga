namespace DeepSpaceSaga.Server.GameLoop.Flow;

public abstract class FlowStepBase<TIn, TOut> : IFlowStep<TIn, TOut>
where TIn : IFlowContext
where TOut : IFlowContext
{
    public TIn FlowContext { get; }

    protected FlowStepBase(TIn flowContext)
    {
        FlowContext = flowContext;
    }
    public abstract TOut Execute(TIn flowContext);
}
