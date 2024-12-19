namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers;

public class HandlersFactory
{
    private readonly List<Func<ICalculationHandler>> _handlerFactories;

    public HandlersFactory()
    {
        _handlerFactories =
        [
            () => new ProcessingLocationsHandler(),
            () => new ProcessingMiningOperationsHandler(),
            () => new ProcessingContentGenerationHandler(),
            () => new ProcessingNavigationHandler(),
            () => new ProcessingScanHandler(),
            () => new ProcessingCommandCleanerHandler()
        ];
    }

    public IEnumerable<ICalculationHandler> CreateHandlers()
    {
        return _handlerFactories.Select(factory => factory());
    }

    public void RegisterHandler(Func<ICalculationHandler> handlerFactory)
    {
        _handlerFactories.Add(handlerFactory);
    }
}
