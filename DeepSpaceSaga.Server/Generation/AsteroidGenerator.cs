namespace DeepSpaceSaga.Server.Generation;

internal class AsteroidGenerator
{
    public static ICelestialObject CreateAsteroid(double direction, double x, double y, double speed, string name, bool isPreScanned = false)
    {
        ICelestialObject asteroid = new BaseCelestialObject
        {
            Id = new GenerationTool().GetId(),
            OwnerId = 0, 
            Name = name,
            Direction = direction,
            PositionX = x,
            PositionY = y,
            Speed = speed,
            Types = CelestialObjectTypes.Asteroid,
            IsPreScanned = isPreScanned
        };

        return asteroid;
    }
}
