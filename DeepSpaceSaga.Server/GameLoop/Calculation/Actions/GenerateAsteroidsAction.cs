namespace DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

public class GenerateAsteroidsAction
{
    private const int DICE_MAX_VALUE = 1000;

    public static SessionContext Execute(SessionContext sessionContext)
    {
        return new GenerateAsteroidsAction().Run(sessionContext);
    }

    public SessionContext Run(SessionContext sessionContext)
    {
        RandomAsteroidGenerate(sessionContext);

        return sessionContext;
    }

    internal void RandomAsteroidGenerate(SessionContext sessionContext)
    {

        var baseGenerationChance = sessionContext.Session.Settings.AsteroidGenerationRatio;

        var diceResult = sessionContext.Randomizer.GetInteger(0, DICE_MAX_VALUE);

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
