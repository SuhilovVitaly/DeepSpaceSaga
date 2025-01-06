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

        var cargo = CargoModulesGenerator.Create(randomizer, spaceship.Id, "CCT9008") as ICargoContainer;

        if(cargo != null)
        {
            cargo.AddItem(new Pombesit(100));
            for (int i = 0; i < 3; i++)
            {
                cargo.AddItem(new IronOre(20 * i));
            }            

            spaceship.Modules.Add(cargo);
        }            

        return spaceship;
    }
}
