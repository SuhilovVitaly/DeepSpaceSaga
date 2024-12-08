namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing.ContentGenerationHandlers;

internal class GenerateAsteroidsPreProcessingHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new GenerateAsteroidsPreProcessingHandler().Run(session, eventsSystem, ticks);
    }

    public GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        RandomAsteroidGenerate(eventsSystem);

        return session;
    }

    internal void RandomAsteroidGenerate(GameEventsSystem eventsSystem)
    {
        var generationTool = new GenerationTool();
        var baseGenerationChance = 990;

        var diceResult = generationTool.GetInteger(0, 1000);

        if (diceResult > baseGenerationChance)
        {
            var command = new Command
            {
                Category = CommandCategory.ContentGeneration,
                Type = CommandTypes.GenerateAsteroid,
                Status = CommandStatus.PreProcess,
                IsOneTimeCommand = true,
            };

            eventsSystem.AddCommand(command);
        }
    }
}
