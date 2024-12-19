namespace DeepSpaceSaga.Server.Generation.Modules;

public class GeneralModuleGenerator
{
    public static IModule CreateSpaceScanner(GenerationTool randomizer, int ownerId, string id)
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
                    ReloadTime = 50,
                    Reloading = 50,
                    Name = "SpaceScanner Mk I"
                };
                break;
        }
        return resultModule;
    }
}
