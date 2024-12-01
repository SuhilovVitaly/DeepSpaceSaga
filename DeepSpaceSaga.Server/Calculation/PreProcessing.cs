namespace DeepSpaceSaga.Server.Calculation;

internal class PreProcessing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        session = new GenerateAsteroidsPreProcessing().Execute(session, eventsSystem, ticks);

        session = new SpacecraftPreProcessing().Execute(session, eventsSystem, ticks);

        session = new ScanPreProcessing().Execute(session, eventsSystem, ticks);

        return session;
    }
}
