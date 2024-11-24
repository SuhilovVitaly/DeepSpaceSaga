using DeepSpaceSaga.Common.Universe.Equipment;

namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

public interface ISpacecraft : ICelestialObject
{
    float MaxSpeed { get; set; }
    float Agility { get; set; }
    List<IModule> Modules { get; set; }
}
