namespace DeepSpaceSaga.Server.Calculation;

public class TurnCalculator
{
    public GameSession Execute(GameSession session, List<Command> commands, int ticks = 1)
    {
        var processingSession = session.Copy();

        RandomAsteroidGenerate(commands);

        foreach (Command command in commands)
        {
            new ContentGenerationProcessing().Execute(processingSession, command);
        }

        return processingSession;
    }

    private void RandomAsteroidGenerate(List<Command> commands)
    {
        var generationTool = new GenerationTool();

        var diceResult = generationTool.GetInteger(0, 100);

        if(diceResult > 90)
        {
            var command = new Command
            {
                Category = CommandCategory.ContentGeneration,
                Type = CommandTypes.GenerateAsteroid
            };

            commands.Add(command);
        }
    }
}
