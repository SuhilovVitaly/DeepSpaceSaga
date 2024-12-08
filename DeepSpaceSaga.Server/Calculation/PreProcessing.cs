namespace DeepSpaceSaga.Server.Calculation;

internal class PreProcessing
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new PreProcessing().Run(session, eventsSystem, ticks);
    }

    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        session = ContentGenerationPreProcessingHandler.Execute(session, eventsSystem, ticks);

        session = AutoRunModulesHandler.Execute(session, eventsSystem, ticks);

        session = EnablingModulesHandler.Execute(session, eventsSystem, ticks);

        session = ModulesReloadingHandler.Execute(session, eventsSystem, ticks);        

        return session;
    }
}
