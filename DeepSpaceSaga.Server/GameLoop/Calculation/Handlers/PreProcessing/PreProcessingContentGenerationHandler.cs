namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

/// <summary>
/// Handler for pre-processing content generation
/// </summary>
public class PreProcessingContentGenerationHandler : BaseHandler, ICalculationHandler
{
    /// <summary>
    /// Execution order of the handler
    /// </summary>
    public int Order => 5;

    /// <summary>
    /// Type of the handler
    /// </summary>
    public HandlerType Type => HandlerType.PreProcessing;

    /// <summary>
    /// Processes the session context by generating required content
    /// </summary>
    /// <param name="sessionContext">Current session context</param>
    /// <returns>Processed session context</returns>
    public SessionContext Handle(SessionContext sessionContext)
    {
        return GenerateAsteroidsAction.Execute(sessionContext);
    }
}
