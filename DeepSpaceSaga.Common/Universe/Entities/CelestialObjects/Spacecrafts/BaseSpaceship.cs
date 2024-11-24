using DeepSpaceSaga.Common.Universe.Equipment;

namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

[Serializable]
public class BaseSpaceship : BaseCelestialObject, ISpacecraft
{
    public float MaxSpeed { get; set; }
    public float Agility { get; set; }
    public List<IModule> Modules { get; set; } = new List<IModule>();
}
