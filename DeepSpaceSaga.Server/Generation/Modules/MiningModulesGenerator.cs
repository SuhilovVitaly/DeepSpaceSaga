namespace DeepSpaceSaga.Server.Generation.Modules;

public class MiningModulesGenerator
{
    public static IModule CreateMiningLaser(GenerationTool randomizer, int ownerId, string id)
    {
        IMiningLaser resultModule = new MiningLaser
        {
            Id = randomizer.GetId(),
            OwnerId = ownerId,
        };

        switch (id)
        {
            case "MLC8002":
                resultModule.MiningRange = 50;
                resultModule.ActivationCost = 100;
                resultModule.Power = 2000;
                resultModule.ReloadTime = 100;
                resultModule.Reloading = 100;
                resultModule.Name = "Civilian Mining Laser";
                break;
        }
        return resultModule;
    }
}
