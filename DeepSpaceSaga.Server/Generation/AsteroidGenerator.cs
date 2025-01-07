namespace DeepSpaceSaga.Server.Generation;

internal class AsteroidGenerator
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(AsteroidGenerator));

    public static ICelestialObject CreateAsteroid(GenerationTool generationTool, double direction, double x, double y, double speed, string name, bool isPreScanned = false)
    {
        try
        {
            ICelestialObject asteroid = new BaseAsteroid
            {
                Id = generationTool.GetId(),
                RemainingDrillAttempts = generationTool.GetInteger(0, 3),
                OwnerId = 0,
                Name = name,
                Direction = direction,
                PositionX = x,
                PositionY = y,
                Speed = speed,
                Types = CelestialObjectTypes.Asteroid,
                IsPreScanned = isPreScanned,
                Size = generationTool.GetFloat(350),
                CoreContainer = new CargoContainer()
            };

            return asteroid;
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            throw;
        }
        
    }
}
