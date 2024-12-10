namespace DeepSpaceSaga.Server.Generation;

internal class SpacecraftGenerator
{
    public static ICelestialObject GetPlayerSpacecraft()
    {
        ISpacecraft spaceship = new BaseSpaceship
        {
            Id = new GenerationTool().GetId(),
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

        spaceship.Modules.Add(PropulsionModulesGenerator.CreateMicroWarpDrive(spaceship.Id, "PMV5002"));
        spaceship.Modules.Add(GeneralModuleGenerator.CreateSpaceScanner(spaceship.Id, "SCR5001"));

        return spaceship;
    }
}
