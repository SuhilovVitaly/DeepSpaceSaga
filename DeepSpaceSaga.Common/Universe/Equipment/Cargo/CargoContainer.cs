using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Common.Universe.Equipment.Mining;

public class CargoContainer : AbstractModule, IModule, ICargoContainer
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(MiningLaser));
    public double Power { get; set; }
    public double Capacity { get; set; } = 0;
    public double MaxCapacity { get; set; } = 0;
    public double ActivationCost { get; set; } = 0;

    public IEnumerable<ICoreItem> Items()
    {
        throw new NotImplementedException();
    }

    public Command Show()
    {
        _log.Info($"Show command for module {Id}");

        var command = new Command
        {
            Category = CommandCategory.CargoOperations,
            Type = CommandTypes.CargoOperationsShow,
            CelestialObjectId = OwnerId,
            TargetCelestialObjectId = 0,
            ModuleId = Id
        };

        _log.Info($"Created command for module {Id}");

        return command;
    }
}
