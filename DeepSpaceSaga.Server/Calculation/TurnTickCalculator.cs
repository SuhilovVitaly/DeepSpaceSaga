namespace DeepSpaceSaga.Server.Calculation;

public class TurnTickCalculator
{
    public GameSession Execute(GameSession session, List<Command> commands, int ticks = 1)
    {
        var processingSession = session.Copy();

        foreach (Command command in commands)
        {
            new NavigationCommandsProcessing().Execute(processingSession, command);
        }

        for (var i = 0; i < ticks; i++)
        {
            processingSession = new DataProcessing.Navigation().Recalculate(processingSession);
        }

        return processingSession;
    }
}
