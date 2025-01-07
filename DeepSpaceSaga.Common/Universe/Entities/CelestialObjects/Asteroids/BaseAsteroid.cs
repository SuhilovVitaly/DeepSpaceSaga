namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Asteroids;

public class BaseAsteroid : BaseCelestialObject, IAsteroid
{
    public int RemainingDrillAttempts { get; set; }
    public required ICargoContainer CoreContainer { get; set; }
}
