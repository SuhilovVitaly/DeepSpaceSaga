namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new TurnCalculator().Run(sessionContext, ticks);
    }

    public SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        var processingSession = new SessionContext(sessionContext.Session.Copy(), sessionContext.EventsSystem.Clone());

        for (var i = 0; i < ticks; i++)
        {
            processingSession = TurnExecution(sessionContext);
        }

        return processingSession;
    }

    internal SessionContext TurnExecution(SessionContext sessionContext)
    {
        sessionContext = PreProcessing.Execute(sessionContext);

        sessionContext = Processing.Execute(sessionContext);

        sessionContext = PostProcessing.Execute(sessionContext);

        sessionContext.Session.TurnTick++;

        return sessionContext;
    }
}
