using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

internal class ProcessingContentGenerationHandler : BaseHandler, ICalculationHandler
{
    public int Order => 1;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (ICommand command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.ContentGeneration))
        {
            context = Run(context, command);
        }
                    
        return context;
    }

    public SessionContext Run(SessionContext sessionContext, ICommand command)
    {
        var currentCelestialObject = command.CelestialObjectId > 0 ? sessionContext.Session.GetCelestialObject(command.CelestialObjectId) : null;

        switch (command.Type)
        {
            case CommandTypes.GenerateAsteroid:
                sessionContext.Metrics.Add(Metrics.ProcessingGenerateAsteroidCommand);
                currentCelestialObject = CelestialMaplestialObjectGeneration(sessionContext, command);
                break;
        }

        AddToJournal(sessionContext, command, currentCelestialObject);

        return sessionContext;
    }

    private ICelestialObject CelestialMaplestialObjectGeneration(SessionContext sessionContext, ICommand command)
    {
        var scannerModule = sessionContext.Session.GetPlayerSpaceShip().GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        if (scannerModule is null) return null;

        var distance = sessionContext.Randomizer.GetInteger((int)(scannerModule.ScanRange - 10), (int)scannerModule.ScanRange);
        var direction = sessionContext.Randomizer.GetInteger(0, 359);
        var velocity = sessionContext.Randomizer.GetDouble(0.1, 10.0);

        var asteroidLocation = GeometryTools.Move(sessionContext.Session.GetPlayerSpaceShip().GetLocation(), distance, sessionContext.Randomizer.GetInteger(0, 359));

        var asteroid = AsteroidGenerator.CreateAsteroid(sessionContext.Randomizer, direction, asteroidLocation.X, asteroidLocation.Y, velocity, sessionContext.Randomizer.GenerateCelestialObjectName());

        sessionContext.Session.SpaceMap.Add(asteroid);

        return asteroid;
    }

    private void AddToJournal(SessionContext sessionContext, ICommand command, ICelestialObject celestialObject)
    {
        sessionContext.Metrics.Add(Metrics.MessageAddedToJournal);

        sessionContext.Session.Logbook.Add(
            new EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = EventType.DetectCelestialObject,
                Text = command.Type.GetDescription() + $" [{Math.Round(celestialObject.PositionX, 0)}:{Math.Round(celestialObject.PositionY, 0)}] {celestialObject.Direction}"
            });
    }
}
