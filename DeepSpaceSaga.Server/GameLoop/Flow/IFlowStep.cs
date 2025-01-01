namespace DeepSpaceSaga.Server.GameLoop.Flow;

public interface IFlowStep<TIn, TOut> where TIn : IFlowContext where TOut : IFlowContext
{
    TOut Execute(TIn context);
    TIn FlowContext { get; }
}
