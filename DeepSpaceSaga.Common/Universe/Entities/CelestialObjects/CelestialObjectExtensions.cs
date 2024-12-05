namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

public static class CelestialObjectExtensions
{
    public static SpaceMapPoint GetLocation(this ICelestialObject celestialObject)
    {
        return new SpaceMapPoint((float)celestialObject.PositionX, (float)celestialObject.PositionY);
    }

    public static SpaceMapColor GetColor(this ICelestialObject celestialObject)
    {
        switch (celestialObject.Types)
        {
            case CelestialObjectTypes.Missile:
                break;
            case CelestialObjectTypes.SpaceshipPlayer:
                return new SpaceMapColor(Color.DarkOliveGreen);
            case CelestialObjectTypes.SpaceshipNpcNeutral:
                return new SpaceMapColor(Color.DarkGray);
            case CelestialObjectTypes.SpaceshipNpcEnemy:
                return new SpaceMapColor(Color.DarkRed);
            case CelestialObjectTypes.SpaceshipNpcFriend:
                return new SpaceMapColor(Color.SeaGreen);
            case CelestialObjectTypes.Asteroid:
                return new SpaceMapColor(Color.WhiteSmoke);
            case CelestialObjectTypes.Explosion:
                break;
        }

        return new SpaceMapColor(Color.FromArgb(30, 45, 65));
    }

    public static ISpacecraft ToSpaceship(this ICelestialObject celestialObject)
    {
        return celestialObject as ISpacecraft;
    }
}
