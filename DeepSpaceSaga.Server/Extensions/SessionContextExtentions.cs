using DeepSpaceSaga.Server.GameLoop.TurnCalculation.Handlers;

namespace DeepSpaceSaga.Server.Extensions;

public static class SessionContextExtentions
{
    public static IOrderedEnumerable<ICalculationHandler> GeHandlers(this SessionContext sessionContext, HandlerType type)
    {
        return sessionContext.CalculationHandlers.Where(x => x.Type == type).OrderBy(o => o.Order);
    }
}
