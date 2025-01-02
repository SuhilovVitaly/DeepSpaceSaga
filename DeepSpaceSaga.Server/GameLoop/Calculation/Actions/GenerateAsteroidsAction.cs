namespace DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

public class GenerateAsteroidsAction
{
    private const int DICE_MAX_VALUE = 1000;

    public static IFlowContext Execute(IFlowContext sessionContext)
    {
        return new GenerateAsteroidsAction().Run(sessionContext);
    }

    public IFlowContext Run(IFlowContext sessionContext)
    {
        RandomAsteroidGenerate(sessionContext);

        return sessionContext;
    }

    internal void RandomAsteroidGenerate(IFlowContext sessionContext)
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
