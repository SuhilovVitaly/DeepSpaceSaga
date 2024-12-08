namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class AutoRunModulesHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new AutoRunModulesHandler().Run(sessionContext,ticks);
    }

    public SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        sessionContext = ScanPreProcessingHandler.Execute(sessionContext, ticks);

        return sessionContext;
    }
}
