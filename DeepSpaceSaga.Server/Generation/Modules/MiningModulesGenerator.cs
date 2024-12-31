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
                resultModule.MiningRange = 300;
                resultModule.ActivationCost = 100;
                resultModule.Power = 2000;
                resultModule.ReloadTime = 10;
                resultModule.Reloading = 10;
                resultModule.Name = "Civilian Mining Laser";
                break;
        }
        return resultModule;
    }
}
