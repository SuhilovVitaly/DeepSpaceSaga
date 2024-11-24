namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

public static class CelestialObjectExtensions
{
    public static PointF GetLocation(this ICelestialObject celestialObject)
    {
        return new PointF((float)celestialObject.PositionX, (float)celestialObject.PositionY);
    }

    public static Color GetColor(this ICelestialObject celestialObject)
    {
        switch (celestialObject.Types)
        {
            case CelestialObjectTypes.Missile:
                break;
            case CelestialObjectTypes.SpaceshipPlayer:
                return Color.DarkOliveGreen;
            case CelestialObjectTypes.SpaceshipNpcNeutral:
                return Color.DarkGray;
            case CelestialObjectTypes.SpaceshipNpcEnemy:
                return Color.DarkRed;
            case CelestialObjectTypes.SpaceshipNpcFriend:
                return Color.SeaGreen;
            case CelestialObjectTypes.Asteroid:
                return Color.DimGray;
            case CelestialObjectTypes.Explosion:
                break;
        }

        return Color.FromArgb(30, 45, 65);
    }

    public static ISpacecraft ToSpaceship(this ICelestialObject celestialObject)
    {
        return celestialObject as ISpacecraft;
    }
}
