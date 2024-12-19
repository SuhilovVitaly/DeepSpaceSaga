namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public static class HandlersPostProcessingCollectionExtensions
{
    public static ConcurrentBag<ICalculationHandler> GetHandlers()
    {
        return new ConcurrentBag<ICalculationHandler>
        {
            new PostProcessingCommandCleanerHandler()
        };
    }
}
