namespace DeepSpaceSaga.Common.Universe.Equipment.Mining;

public class MiningLaser : AbstractModule, IModule, IMiningLaser
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(MiningLaser));

    public Category Category { get; set; } = Category.MiningLaser;
    public double ActivationCost { get; set; }
    public double Power { get; set; }
    public double MiningRange { get; set; }

    public Command Harvest(int targetCelestialObjectId)
    {
        _log.Info($"Creating harvest command for mining laser {Id} targeting celestial object {targetCelestialObjectId}");

        var command = new Command
        {
            Category = CommandCategory.Mining,
            Type = CommandTypes.MiningOperationsHarvest,
            CelestialObjectId = OwnerId,
            TargetCelestialObjectId = targetCelestialObjectId,
            ModuleId = Id
        };

        _log.Debug($"Created harvest command: {JsonConvert.SerializeObject(command)}");
        return command;
    }
}
