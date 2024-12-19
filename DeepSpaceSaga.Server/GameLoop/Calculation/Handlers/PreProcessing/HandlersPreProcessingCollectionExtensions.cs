namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public static class HandlersPreProcessingCollectionExtensions
{
    public static IEnumerable<ICalculationHandler> GetHandlers()
    {
        return
        [
            new PreProcessingScanHandler(),
            new PreProcessingModulesEnablingHandler(),
            new PreProcessingModulesReloadingHandler(),
            new PreProcessingContentGenerationHandler()
        ];
    }
}
