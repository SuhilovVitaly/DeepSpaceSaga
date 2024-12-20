namespace DeepSpaceSaga.Server.Generation.Modules;

public class CargoModulesGenerator
{
    public static IModule Create(GenerationTool randomizer, int ownerId, string id)
    {
        ICargoContainer resultModule = new CargoContainer
        {
            Id = randomizer.GetId(),
            OwnerId = ownerId,
        };

        switch (id)
        {
            case "CCT9008":
                resultModule.ActivationCost = 0;
                resultModule.Power = 200;
                resultModule.ReloadTime = 0;
                resultModule.Reloading = 0;
                resultModule.MaxCapacity = 8000;
                resultModule.Name = "Civilian container 8T";
                break;
        }
        return resultModule;
    }
}