namespace DeepSpaceSaga.Server.GameLoop.Calculation.Actions.Mining;

public class GenerateAsteroidHarcestResult
{
    public static List<ICoreItem> Execute(IFlowContext sessionContext, ICommand command)
    {
        var spacecraft = sessionContext.Session.GetCelestialObject(command.CelestialObjectId) as ISpacecraft;
        var asteroid = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId) as IAsteroid;

        // TODO: Use asteroid properties for generation harvest results

        var harvestResult = new List<ICoreItem>();

        harvestResult.AddRange(GenerateOrePombesit(sessionContext, spacecraft, asteroid));
        harvestResult.AddRange(GenerateOreIron(sessionContext, spacecraft, asteroid));

        return harvestResult;
    }


    private static List<ICoreItem> GenerateOrePombesit(IFlowContext sessionContext, ISpacecraft? spacecraft, IAsteroid? asteroid)
    {
        var result = new List<ICoreItem>();

        var ore = new Pombesit(sessionContext.Randomizer.GetInteger(1,4));

        result.Add(ore);

        return result;
    }

    private static List<ICoreItem> GenerateOreIron(IFlowContext sessionContext, ISpacecraft? spacecraft, IAsteroid? asteroid)
    {
        var result = new List<ICoreItem>();

        var ore = new IronOre(sessionContext.Randomizer.GetInteger(1, 3));

        result.Add(ore);

        return result;
    }
}
