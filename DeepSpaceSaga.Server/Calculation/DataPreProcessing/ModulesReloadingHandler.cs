namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ModulesReloadingHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new ModulesReloadingHandler().Run(session, eventsSystem, ticks);
    }

    public GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        var spacecraft = session.GetPlayerSpaceShip();

        foreach (var moudle in spacecraft.Modules)
        {
            if (moudle.IsReloaded == false)
            {
                moudle.Reload();

                if (moudle.IsReloaded)
                {
                   eventsSystem.ProcessModuleResults(spacecraft, moudle);
                }
            }
        }

        return session;
    }
}
