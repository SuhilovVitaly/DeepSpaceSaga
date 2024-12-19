namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public static class HandlersProcessingCollectionExtensions
{
    /// <summary>
    /// Returns collection of calculation handlers in processing pipeline
    /// </summary>
    public static IEnumerable<ICalculationHandler> GetHandlers()
    {
        return
        [
            new ProcessingMiningOperationsHandler(),
            new ProcessingContentGenerationHandler(),
            new ProcessingNavigationHandler(),
            new ProcessingScanHandler(),
            new ProcessingCommandCleanerHandler()
        ];
    }
}
