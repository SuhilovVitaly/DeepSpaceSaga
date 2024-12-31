using DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Containers;
using DeepSpaceSaga.Common.Universe.Items;
using DeepSpaceSaga.Common.Universe.Items.Ore;

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
        
        var module = sourceCelestialObject.ToSpaceship().GetModule(command.ModuleId);

        var container = GenerateContainer(sessionContext, sourceCelestialObject, targetCelestialObject);

        var ore = GenerateOreItems(sessionContext, sourceCelestialObject, targetCelestialObject);

        container.Items.AddRange(ore);

        sessionContext.Session.SpaceMap.Add((ICelestialObject)container);

        var uiEvent = EventsFactory.CreateEvent(sessionContext.Randomizer, command, module, (ICelestialObject)container, sourceCelestialObject);
        uiEvent.CalculationTurnId = sessionContext.Session.Metrics.TurnTick;
        sessionContext.Session.Events.Add(uiEvent);

        return sessionContext;
    }

    private IContainer GenerateContainer(SessionContext sessionContext, ICelestialObject sourceCelestialObject, ICelestialObject targetCelestialObject)
    {
        IContainer container = new OreContainer
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

    private List<ICoreItem> GenerateOreItems(SessionContext sessionContext, ICelestialObject sourceCelestialObject, ICelestialObject targetCelestialObject)
    {
        var result = new List<ICoreItem>();

        var ore = new Pombesit(sessionContext.Randomizer.GetInteger(1,12));

        result.Add(ore);

        return result;
    }
}
