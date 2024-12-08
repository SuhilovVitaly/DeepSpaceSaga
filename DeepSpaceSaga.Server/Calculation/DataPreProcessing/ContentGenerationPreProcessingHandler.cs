namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ContentGenerationPreProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new ContentGenerationPreProcessingHandler().Run(sessionContext, ticks);
    }

    internal SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        sessionContext = GenerateAsteroidsPreProcessingHandler.Execute(sessionContext, ticks);

        return sessionContext;
    }
}
