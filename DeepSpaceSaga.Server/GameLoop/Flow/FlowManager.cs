namespace DeepSpaceSaga.Server.GameLoop.Flow;

public class FlowManager<T> where T : IFlowContext, new()
{
    private readonly FlowStepFactory _factory;
    private readonly IFlowContext _sessionContext;

    public FlowManager(FlowStepFactory factory, IFlowContext sessionContext)
    {
        _factory = factory;
        _sessionContext = sessionContext;
    }

    public T Initialize()
    {
        return (T)_sessionContext;        
    }
}
