namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ContentGenerationPreProcessingHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new ContentGenerationPreProcessingHandler().Run(session, eventsSystem, ticks);
    }

    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        session = GenerateAsteroidsPreProcessingHandler.Execute(session, eventsSystem, ticks);

        return session;
    }
}
