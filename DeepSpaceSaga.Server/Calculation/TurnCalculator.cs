namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public GameSession Execute(GameSession session, List<Command> commands, int ticks = 1)
    {
        var processingSession = session.Copy();

        foreach (Command command in commands)
        {
            new ContentGenerationProcessing().Execute(processingSession, command);
        }

        return processingSession;
    }
}
