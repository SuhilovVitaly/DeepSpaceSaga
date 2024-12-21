namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PostProcessing;

public class PostProcessingTurnInfoUpdateHandler : BaseHandler, ICalculationHandler
{
    /// <summary>
    /// Defines the order of handler execution
    /// </summary>
    public int Order => 1;

    /// <summary>
    /// Type of the handler
    /// </summary>
    public HandlerType Type => HandlerType.PostProcessing;

    /// <summary>
    /// Processes the session context
    /// </summary>
    /// <param name="context">Session context</param>
    /// <returns>Processed session context</returns>
    public SessionContext Handle(SessionContext context)
    {
        context.Session.TurnsTicks++;
        context.Session.TurnTick++;

        if(context.Session.TurnTick >= 10)
        {
            context.Session.TurnTick = 0;
            context.Session.Turn++;
        }
        
        return context;
    }

}
