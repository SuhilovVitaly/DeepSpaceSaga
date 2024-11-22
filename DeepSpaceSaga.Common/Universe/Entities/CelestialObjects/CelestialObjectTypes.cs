namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

[Serializable]
public enum CelestialObjectTypes
{
    None = -1000,
    PointInMap = -1,
    Asteroid = 1,
    Station = 100,
    SpaceshipPlayer = 200,
    SpaceshipNpcNeutral = 201,
    SpaceshipNpcEnemy = 202,
    SpaceshipNpcFriend = 203,
    Missile = 300,
    Explosion = 800
}
