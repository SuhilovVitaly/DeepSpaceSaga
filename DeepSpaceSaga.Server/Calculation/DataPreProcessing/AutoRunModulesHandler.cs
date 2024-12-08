namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class AutoRunModulesHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new AutoRunModulesHandler().Run(session, eventsSystem, ticks);
    }

    public GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        session = ScanPreProcessingHandler.Execute(session, eventsSystem, ticks);

        return session;
    }
}
