namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Asteroids;

public class BaseAsteroid(int maxDrillAttempts) : BaseCelestialObject, IAsteroid
{
    public int RemainingDrillAttempts { get; private set; } = maxDrillAttempts;
    public required ICargoContainer CoreContainer { get; set; }

    public void Drill()
    {
        RemainingDrillAttempts--;
    }
}
