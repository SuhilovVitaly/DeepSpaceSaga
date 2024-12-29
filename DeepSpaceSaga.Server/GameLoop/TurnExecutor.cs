namespace DeepSpaceSaga.Server.GameLoop;

public class TurnExecutor
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(TurnExecutor));

    public static SessionContext Execute(SessionContext context, ConcurrentBag<ICalculationHandler> handlers)
    {
        var processingSession = new SessionContext(
            context.Session.Copy(),
            context.EventsSystem.Clone(),
            context.Metrics,
            context.Randomizer,
            context.Settings);

        context.Session.Events = new GameActionEvents([]);

        for (var i = 0; i < processingSession.Session.State.Speed; i++)
        {
            var stopwatch = Stopwatch.StartNew();

            processingSession = TurnExecution(context, handlers);

            stopwatch.Stop();

            double milliseconds = stopwatch.ElapsedTicks * 1000.0 / Stopwatch.Frequency;

            context.Metrics.AddMilliseconds(Metrics.CalculationTurnAvg, milliseconds);

            _log.Debug($"Calculation is {stopwatch.ElapsedTicks} Avg is {context.Metrics.GetAverageMillisecondst(Metrics.CalculationTurnAvg)}");
        }        

        return processingSession;
    }

    public static SessionContext TurnExecution(SessionContext context, ConcurrentBag<ICalculationHandler> handlers)
    {
        _log.Debug($"Starting turn calculation PreProcessing for session turn {context.Session.Metrics.TurnTick}");

        // TODO: Move to extantion
        foreach (var handler in handlers.GeHandlers(HandlerType.PreProcessing))
        {
            context = handler.Handle(context);
        }

        _log.Debug($"Starting turn calculation Processing for session turn {context.Session.Metrics.TurnTick}");

        foreach (var handler in handlers.GeHandlers(HandlerType.Processing))
        {
            context = handler.Handle(context);
        }

        _log.Debug($"Starting turn calculation PostProcessing for session turn {context.Session.Metrics.TurnTick}");

        foreach (var handler in handlers.GeHandlers(HandlerType.PostProcessing))
        {
            context = handler.Handle(context);
        }

        return context;
    }
}
