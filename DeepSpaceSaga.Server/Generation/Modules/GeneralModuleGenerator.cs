namespace DeepSpaceSaga.Server.Generation.Modules;

public class GeneralModuleGenerator
{
    public static IModule CreateSpaceScanner(int ownerId, string id)
    {
        IModule resultModule = null;

        switch (id)
        {
            case "SCR5001":
                resultModule = new SpaceScanner
                {
                    Id = new GenerationTool().GetId(),
                    OwnerId = ownerId,
                    Category = Category.SpaceScanner,
                    ScanRange = 1400,
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
