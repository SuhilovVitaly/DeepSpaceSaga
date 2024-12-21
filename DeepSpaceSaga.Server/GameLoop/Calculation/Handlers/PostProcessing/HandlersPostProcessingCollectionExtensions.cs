namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public static class HandlersPostProcessingCollectionExtensions
{
    public static IEnumerable<ICalculationHandler> GetHandlers()
    {
        return
        [
            new PostProcessingCommandCleanerHandler(),
            new PostProcessingTurnInfoUpdateHandler(),
        ];
    }
}
