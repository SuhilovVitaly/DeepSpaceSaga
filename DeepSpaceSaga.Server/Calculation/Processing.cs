namespace DeepSpaceSaga.Server.Calculation;

internal class Processing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        foreach (Command command in eventsSystem.Commands)
        {
            new ContentGenerationProcessing().Execute(session, command);

            new ScanProcessing().Execute(session, command);
        }

        return session;
    }
}
