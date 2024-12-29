namespace DeepSpaceSaga.Server.Extensions;

public static class SessionContextExtentions
{

    public static IOrderedEnumerable<ICalculationHandler> GeHandlers(this ConcurrentBag<ICalculationHandler> handlers, HandlerType type)
    {
        return handlers.Where(x => x.Type == type).OrderBy(o => o.Order);
    }
}
