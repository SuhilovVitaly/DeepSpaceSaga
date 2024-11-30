namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ContentGenerationProcessing
{
    public void Execute(GameSession session, Command command)
    {
        var currentCelestialObject = command.CelestialObjectId > 0 ? session.GetCelestialObject(command.CelestialObjectId) : null;

        switch (command.Type)
        {
            case CommandTypes.GenerateAsteroid:
                currentCelestialObject = CelestialMaplestialObjectGeneration(session, command);
                break;
        }

        AddToJournal(session, command, currentCelestialObject);
    }

    private ICelestialObject CelestialMaplestialObjectGeneration(GameSession session, Command command)
    {
        var generationTool = new GenerationTool();

        var scannerModule = session.GetPlayerSpaceShip().GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        if (scannerModule is null) return null;

        var distance = generationTool.GetInteger((int)(scannerModule.ScanRange - 50), (int)scannerModule.ScanRange) / 2;
        var direction = generationTool.GetInteger(0, 359);
        var velocity = generationTool.GetDouble(0.1, 10.0);

        var asteroidLocation = GeometryTools.Move(session.GetPlayerSpaceShip().GetLocation(), distance, generationTool.GetInteger(0, 359));

        var asteroid = AsteroidGenerator.CreateAsteroid(direction, asteroidLocation.X, asteroidLocation.Y, velocity, generationTool.GenerateCelestialObjectName());

        session.SpaceMap.Add(asteroid);

        return asteroid;
    }

    private void AddToJournal(GameSession session, Command command, ICelestialObject celestialObject)
    {
        session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = command.Type.GetDescription() + $" [{Math.Round(celestialObject.PositionX,0)}:{Math.Round(celestialObject.PositionY, 0)}] {celestialObject.Direction}"
            });
    }
}
