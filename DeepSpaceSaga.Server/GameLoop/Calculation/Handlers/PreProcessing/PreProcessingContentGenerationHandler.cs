using DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingContentGenerationHandler : BaseHandler, ICalculationHandler
{
    public int Order => 5;

    public HandlerType Type => HandlerType.PreProcessing;

    public SessionContext Handle(SessionContext sessionContext)
    {
        sessionContext = GenerateAsteroidsAction.Execute(sessionContext);

        return sessionContext;
    }
}
