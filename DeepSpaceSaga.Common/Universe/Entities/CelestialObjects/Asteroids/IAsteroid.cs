namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Asteroids;

public interface IAsteroid : ICelestialObject
{
    int RemainingDrillAttempts { get; }
}
