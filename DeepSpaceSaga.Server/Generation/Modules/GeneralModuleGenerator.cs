namespace DeepSpaceSaga.Server.Generation.Modules;

public class GeneralModuleGenerator
{
    public static IModule CreateSpaceScanner(IGenerationTool randomizer, int ownerId, string id)
    {
        IModule resultModule = null;

        switch (id)
        {
            case "SCR5001":
                resultModule = new SpaceScanner
                {
                    Id = randomizer.GetId(),
                    OwnerId = ownerId,
                    Category = Category.SpaceScanner,
                    ScanRange = 700,
                    Power = 55,
                    ActivationCost = 10,
                    ReloadTime = 5,
                    Reloading = 5,
                    Name = "SpaceScanner Mk I"
                };
                break;
        }
        return resultModule;
    }
}
