namespace DeepSpaceSaga.Server.Generation.Modules;

public class PropulsionModulesGenerator
{
    public static IModule CreateMicroWarpDrive(int ownerId, string id)
    {
        IModule resultModule = null;

        switch (id)
        {
            case "PMV5002":
                resultModule = new MicroWarpDrive
                {
                    Id = new GenerationTool().GetId(),
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
