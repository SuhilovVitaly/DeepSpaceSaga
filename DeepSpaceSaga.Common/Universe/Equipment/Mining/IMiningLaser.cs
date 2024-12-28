using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Common.Universe.Equipment.Mining;

public interface IMiningLaser : IModule
{
    double Power { get; set; }
    double MiningRange { get; set; }
    Command Harvest(int targetCelestialObjectId);
}
