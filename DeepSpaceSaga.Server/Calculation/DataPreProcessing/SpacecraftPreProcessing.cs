namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class SpacecraftPreProcessing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
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
