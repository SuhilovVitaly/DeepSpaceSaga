namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing.ContentGenerationHandlers;

internal class GenerateAsteroidsPreProcessingHandler
{
    private const int DICE_MAX_VALUE = 1000;

    public static SessionContext Execute(SessionContext sessionContext)
    {
        return new GenerateAsteroidsPreProcessingHandler().Run(sessionContext);
    }

    public SessionContext Run(SessionContext sessionContext)
    {
        RandomAsteroidGenerate(sessionContext);

        return sessionContext;
    }

    internal void RandomAsteroidGenerate(SessionContext sessionContext)
    {
        var generationTool = new GenerationTool();
        var baseGenerationChance = sessionContext.Session.Settings.AsteroidGenerationRatio;

        var diceResult = generationTool.GetInteger(0, DICE_MAX_VALUE);

        if (diceResult > baseGenerationChance)
        {
            sessionContext.Metrics.Add(Metrics.PreProcessingGenerateNewAsteroidCommand);
            var command = new Command
            {
                Category = CommandCategory.ContentGeneration,
                Type = CommandTypes.GenerateAsteroid,
                Status = CommandStatus.PreProcess,
                IsOneTimeCommand = true,
            };

            sessionContext.EventsSystem.AddCommand(command);
        }
    }
}
