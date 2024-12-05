namespace DeepSpaceSaga.Server.Calculation;

public class TurnTickCalculator
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, List<Command> commands, int ticks = 1)
    {
        var processingSession = session.Copy();

        foreach (Command command in commands)
        {
            new NavigationCommandsProcessing().Execute(processingSession, command);
        }

        for (var i = 0; i < ticks; i++)
        {
            processingSession = new Navigation().Recalculate(processingSession);

            processingSession = new GameEventsProcessing().Execute(processingSession, eventsSystem, ticks);

            processingSession = new PreProcessing().Execute(processingSession, eventsSystem, ticks);

            processingSession = new Processing().Execute(processingSession, eventsSystem, ticks);

            processingSession = new PostProcessing().Execute(processingSession, eventsSystem, ticks);
        }

        return processingSession;
    }
}
