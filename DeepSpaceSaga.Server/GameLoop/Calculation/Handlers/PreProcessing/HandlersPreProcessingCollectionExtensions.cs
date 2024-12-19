namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public static class HandlersPreProcessingCollectionExtensions
{
    public static ConcurrentBag<ICalculationHandler> GetHandlers()
    {
        return new ConcurrentBag<ICalculationHandler>
        {
            new PreProcessingScanHandler(),
            new PreProcessingModulesEnablingHandler(),
            new PreProcessingModulesReloadingHandler(),
            new PreProcessingContentGenerationHandler()
        };
    }
}
