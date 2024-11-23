namespace DeepSpaceSaga.Server.Generation;

internal class AsteroidGenerator
{
    public static ICelestialObject CreateAsteroid(double direction, double x, double y, double speed, string name)
    {

        ICelestialObject spaceship = new BaseCelestialObject
        {
            Id = RandomGenerator.GetId(),
            OwnerId = 0, 
            Name = name,
            Direction = direction,
            PositionX = x,
            PositionY = y,
            Speed = speed,
            Types = CelestialObjectTypes.Asteroid
        };

        return spaceship;
    }
}
