﻿namespace DeepSpaceSaga.Server.Generation.Modules;

public class PropulsionModulesGenerator
{
    public static IModule CreateMicroWarpDrive(IGenerationTool randomizer, int ownerId, string id)
    {
        IModule resultModule = null;

        switch (id)
        {
            case "PMV5002":
                resultModule = new MicroWarpDrive
                {
                    Id = randomizer.GetId(),
                    OwnerId = ownerId,
                    ActivationCost = 100,
                    Power = 2000,
                    ReloadTime = 2,
                    Reloading = 2,
                    Category = Category.Propulsion,
                    Name = "Civilian MkIp"
                };
                break;
        }
        return resultModule;
    }
}
