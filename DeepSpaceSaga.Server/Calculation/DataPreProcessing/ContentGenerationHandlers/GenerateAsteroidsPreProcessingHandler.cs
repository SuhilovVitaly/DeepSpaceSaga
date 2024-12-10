namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing.ContentGenerationHandlers;

internal class GenerateAsteroidsPreProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new GenerateAsteroidsPreProcessingHandler().Run(sessionContext,  ticks);
    }

    public SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        RandomAsteroidGenerate(sessionContext);

        return sessionContext;
    }

    internal void RandomAsteroidGenerate(SessionContext sessionContext)
    {
        var generationTool = new GenerationTool();
        var baseGenerationChance = sessionContext.Session.Settings.AsteroidGenerationRatio;

        var diceResult = generationTool.GetInteger(0, 1000);

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
