using DeepSpaceSaga.Common.Tools;

namespace DeepSpaceSaga.Server.Generation;

internal class SpacecraftGenerator
{
    public static ICelestialObject GetPlayerSpacecraft()
    {

        ICelestialObject spaceship = new BaseSpaceship
        {
            Id = RandomGenerator.GetId(),
            OwnerId = 1, // Player Spacecraft
            Name = "Glowworm",
            Direction = 90,
            PositionX = 10000,
            PositionY = 10000,
            Speed = 1,
            MaxSpeed = 10,
        };

        return spaceship;
    }
}
