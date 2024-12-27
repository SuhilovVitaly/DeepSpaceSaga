namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

[Serializable]
public enum CelestialObjectTypes
{
    None = -1000,
    PointInMap = -1,
    [Description("Asteroid")]
    Asteroid = 1,
    [Description("Station")]
    Station = 100,
    [Description("Spaceship")]
    SpaceshipPlayer = 200,
    [Description("Spaceship")]
    SpaceshipNpcNeutral = 201,
    [Description("Spaceship")]
    SpaceshipNpcEnemy = 202,
    [Description("Spaceship")]
    SpaceshipNpcFriend = 203,
    [Description("Missile")]
    Missile = 300,
    Explosion = 800,
    Container = 1000
}
