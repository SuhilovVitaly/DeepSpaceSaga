namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ContentGenerationProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, Command command)
    {
        return new ContentGenerationProcessingHandler().Run(sessionContext, command);
    }

    public SessionContext Run(SessionContext sessionContext, Command command)
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

    private ICelestialObject CelestialMaplestialObjectGeneration(SessionContext sessionContext, Command command)
    {
        var scannerModule = sessionContext.Session.GetPlayerSpaceShip().GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        if (scannerModule is null) return null;

        var distance = sessionContext.Randomizer.GetInteger((int)(scannerModule.ScanRange - 10), (int)scannerModule.ScanRange) ;
        var direction = sessionContext.Randomizer.GetInteger(0, 359);
        var velocity = sessionContext.Randomizer.GetDouble(0.1, 10.0);

        var asteroidLocation = GeometryTools.Move(sessionContext.Session.GetPlayerSpaceShip().GetLocation(), distance, sessionContext.Randomizer.GetInteger(0, 359));

        var asteroid = AsteroidGenerator.CreateAsteroid(sessionContext.Randomizer, direction, asteroidLocation.X, asteroidLocation.Y, velocity, sessionContext.Randomizer.GenerateCelestialObjectName());

        sessionContext.Session.SpaceMap.Add(asteroid);

        return asteroid;
    }

    private void AddToJournal(SessionContext sessionContext, Command command, ICelestialObject celestialObject)
    {
        sessionContext.Metrics.Add(Metrics.MessageAddedToJournal);

        sessionContext.Session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = command.Type.GetDescription() + $" [{Math.Round(celestialObject.PositionX,0)}:{Math.Round(celestialObject.PositionY, 0)}] {celestialObject.Direction}"
            });
    }
}
