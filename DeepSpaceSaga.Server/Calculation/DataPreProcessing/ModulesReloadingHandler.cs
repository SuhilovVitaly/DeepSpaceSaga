namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ModulesReloadingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new ModulesReloadingHandler().Run(sessionContext, ticks);
    }

    public SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        foreach (var moudle in spacecraft.Modules)
        {
            if (moudle.IsReloaded == false)
            {
                moudle.Reload();

                if (moudle.IsReloaded)
                {
                    sessionContext.EventsSystem.ProcessModuleResults(spacecraft, moudle);
                }
            }
        }

        return sessionContext;
    }
}
