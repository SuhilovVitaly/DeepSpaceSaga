namespace DeepSpaceSaga.Server.GameLoop.Calculation.Actions.Mining;

public class GenerateAsteroidHarcestResult
{
    public static SessionContext Execute(SessionContext sessionContext, ICommand command)
    {
        return new GenerateAsteroidHarcestResult().Run(sessionContext, command);
    }

    public SessionContext Run(SessionContext sessionContext, ICommand command)
    {
        var sourceCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        var container = GenerateContainer(sessionContext, sourceCelestialObject, targetCelestialObject);

        sessionContext.Session.SpaceMap.Add(container);

        return sessionContext;
    }

    private ICelestialObject GenerateContainer(SessionContext sessionContext, ICelestialObject sourceCelestialObject, ICelestialObject targetCelestialObject)
    {
        ICelestialObject container = new BaseCelestialObject
        {
            Id = sessionContext.Randomizer.GetId(),
            OwnerId = sourceCelestialObject.Id,
            Name = "Container-" + sessionContext.Randomizer.RandomString(4) + "-" + sessionContext.Randomizer.RandomNumber(4),
            Direction = targetCelestialObject.Direction,
            PositionX = targetCelestialObject.PositionX + sessionContext.Randomizer.GetInteger(1, 20),
            PositionY = targetCelestialObject.PositionY + sessionContext.Randomizer.GetInteger(1, 20),
            Speed = targetCelestialObject.Speed,
            Types = CelestialObjectTypes.Container,
            IsPreScanned = true,
            Size = 1
        };

        return container;
    }
}
