﻿namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public static SessionContext Execute(SessionContext sessionContext)
    {
        return new TurnCalculator().Run(sessionContext);
    }

    public SessionContext Run(SessionContext sessionContext)
    {
        var processingSession = new SessionContext(
            sessionContext.Session.Copy(), 
            sessionContext.EventsSystem.Clone(), 
            sessionContext.Metrics);

        for (var i = 0; i < processingSession.Session.State.Speed; i++)
        {
            var stopwatch = Stopwatch.StartNew();

            processingSession = TurnExecution(sessionContext);

            stopwatch.Stop();

            sessionContext.Metrics.AddMilliseconds(Metrics.CalculationTurnAvg, stopwatch.ElapsedMilliseconds);
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
