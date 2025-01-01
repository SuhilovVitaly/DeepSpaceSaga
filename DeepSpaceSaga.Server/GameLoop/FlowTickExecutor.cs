namespace DeepSpaceSaga.Server.GameLoop;

public class FlowTickExecutor
{
    public static IFlowContext ExecuteTick(IFlowContext context)
    {
        var sessionContext = new SessionContext(
            context.Session.Copy(),
            context.EventsSystem.Clone(),
            context.Metrics,
            context.Randomizer,
            context.Settings);


        var flowManager = new FlowManager<SessionContext>(FlowStepFactory.Instance, sessionContext);

        var result = flowManager
            .Initialize()
            .PreProcessingValidateInput()
            .ProcessingLocations()
            .PostProcessingFinishFlow();

        return result.FlowContext;

    }
}
