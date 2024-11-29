namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ContentGenerationProcessing
{
    public void Execute(GameSession session, Command command)
    {
        var currentCelestialObject = command.CelestialObjectId > 0 ? session.GetCelestialObject(command.CelestialObjectId) : null;

        switch (command.Type)
        {
            case Common.Universe.Commands.CommandTypes.GenerateAsteroid:
                CelestialMaplestialObjectGeneration (session, command);
                break;
        }
    }

    private void CelestialMaplestialObjectGeneration(GameSession session, Command command)
    {
        var generationTool = new GenerationTool();

        var scannerModule = session.GetPlayerSpaceShip().GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        if (scannerModule is null) return;

        var distance = generationTool.GetInteger((int)(scannerModule.ScanRange - 50), (int)scannerModule.ScanRange);
        var direction = generationTool.GetInteger(0, 359);
        var velocity = generationTool.GetDouble(0.1, 10.0);

        var asteroidLocation = GeometryTools.Move(session.GetPlayerSpaceShip().GetLocation(), distance, generationTool.GetInteger(0, 359));

        var asteroid = AsteroidGenerator.CreateAsteroid(direction, asteroidLocation.X, asteroidLocation.Y, velocity, generationTool.GenerateCelestialObjectName());

        session.SpaceMap.Add(asteroid);
    }
}
