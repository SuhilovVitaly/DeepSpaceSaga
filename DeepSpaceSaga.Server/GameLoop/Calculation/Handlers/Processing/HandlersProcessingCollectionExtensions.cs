using DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public static class HandlersProcessingCollectionExtensions
{
    public static ConcurrentBag<ICalculationHandler> GetHandlers()
    {
        return new ConcurrentBag<ICalculationHandler>
        {
            new ProcessingLocationsHandler(),
            new ProcessingMiningOperationsHandler(),
            new ProcessingContentGenerationHandler(),
            new ProcessingNavigationHandler(),
            new ProcessingScanHandler(),
            new ProcessingCommandCleanerHandler()
        };
    }
}
