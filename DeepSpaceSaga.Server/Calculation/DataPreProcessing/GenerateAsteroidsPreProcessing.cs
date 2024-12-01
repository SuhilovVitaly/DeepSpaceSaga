namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class GenerateAsteroidsPreProcessing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        RandomAsteroidGenerate(eventsSystem);

        return session;
    }

    private void RandomAsteroidGenerate(GameEventsSystem eventsSystem)
    {
        var generationTool = new GenerationTool();

        var diceResult = generationTool.GetInteger(0, 100);

        if (diceResult > 90)
        {
            var command = new Command
            {
                Category = CommandCategory.ContentGeneration,
                Type = CommandTypes.GenerateAsteroid
            };

            eventsSystem.AddCommand(command);
        }
    }
}
