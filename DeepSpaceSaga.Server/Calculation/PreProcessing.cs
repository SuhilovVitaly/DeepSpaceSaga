namespace DeepSpaceSaga.Server.Calculation;

internal class PreProcessing
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new PreProcessing().Run(sessionContext, ticks);
    }

    internal SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        sessionContext = ContentGenerationPreProcessingHandler.Execute(sessionContext, ticks);

        sessionContext = AutoRunModulesHandler.Execute(sessionContext, ticks);

        sessionContext = EnablingModulesHandler.Execute(sessionContext, ticks);

        sessionContext = ModulesReloadingHandler.Execute(sessionContext, ticks);        

        return sessionContext;
    }
}
