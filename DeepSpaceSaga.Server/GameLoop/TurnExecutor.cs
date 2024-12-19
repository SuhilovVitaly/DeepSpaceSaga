namespace DeepSpaceSaga.Server.GameLoop;

public class TurnExecutor
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(TurnExecutor));

    public static SessionContext Execute(SessionContext context)
    {
        _log.Info($"Starting turn calculation PreProcessing for session turn {context.Session.TurnTick}");

        foreach (var handler in context.CalculationHandlers.Where(x => x.Type == HandlerType.PreProcessing).OrderBy(o => o.Order))
        {
            context = handler.Handle(context);
        }

        _log.Info($"Starting turn calculation Processing for session turn {context.Session.TurnTick}");

        foreach (var handler in context.CalculationHandlers.Where(x => x.Type == HandlerType.Processing).OrderBy(o => o.Order))
        {
            context = handler.Handle(context);
        }

        _log.Info($"Starting turn calculation PostProcessing for session turn {context.Session.TurnTick}");

        foreach (var handler in context.CalculationHandlers.Where(x => x.Type == HandlerType.PostProcessing).OrderBy(o => o.Order))
        {
            context = handler.Handle(context);
        }

        return context;
    }
}
