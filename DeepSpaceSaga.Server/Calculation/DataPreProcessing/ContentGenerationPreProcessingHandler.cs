namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ContentGenerationPreProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext)
    {
        return new ContentGenerationPreProcessingHandler().Run(sessionContext);
    }

    internal SessionContext Run(SessionContext sessionContext)
    {
        sessionContext = GenerateAsteroidsPreProcessingHandler.Execute(sessionContext);

        return sessionContext;
    }
}
