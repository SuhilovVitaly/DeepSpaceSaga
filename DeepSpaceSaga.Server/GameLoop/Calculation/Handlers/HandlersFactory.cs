namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers;

public class HandlersFactory
{
    public static ConcurrentBag<ICalculationHandler> GetTickHandlers()
    {
        ConcurrentBag<ICalculationHandler> handlers =
        [
            //new ProcessingLocationsHandler(),
            new PostProcessingTurnInfoUpdateHandler(),
            new PreProcessingModulesReloadingHandler()
        ];

        return handlers;
    }

    public static ConcurrentBag<ICalculationHandler> GetTurnHandlers()
    {
        ConcurrentBag<ICalculationHandler> handlers =
        [
            .. HandlersPreProcessingCollectionExtensions.GetHandlers(),
            .. HandlersProcessingCollectionExtensions.GetHandlers(),
            .. HandlersPostProcessingCollectionExtensions.GetHandlers(),
        ];

        return handlers;
    }
}
