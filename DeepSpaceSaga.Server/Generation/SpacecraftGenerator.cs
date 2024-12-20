namespace DeepSpaceSaga.Server.Generation;

internal class SpacecraftGenerator
{
    public static ICelestialObject GetPlayerSpacecraft(GenerationTool randomizer)
    {
        ISpacecraft spaceship = new BaseSpaceship
        {
            Id = randomizer.GetId(),
            OwnerId = 1, 
            Name = "Glowworm",
            Direction = 45,
            PositionX = 10000,
            PositionY = 10000,
            Speed = 10,
            MaxSpeed = 20,
            Agility = 5,
            Size = 30,
            Types = CelestialObjectTypes.SpaceshipPlayer
        };

        spaceship.Modules.Add(PropulsionModulesGenerator.CreateMicroWarpDrive(randomizer, spaceship.Id, "PMV5002"));
        spaceship.Modules.Add(GeneralModuleGenerator.CreateSpaceScanner(randomizer, spaceship.Id, "SCR5001"));
        spaceship.Modules.Add(MiningModulesGenerator.CreateMiningLaser(randomizer, spaceship.Id, "MLC8002"));
        spaceship.Modules.Add(CargoModulesGenerator.Create(randomizer, spaceship.Id, "CCT9008"));

        return spaceship;
    }
}
