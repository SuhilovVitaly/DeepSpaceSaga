namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

[Serializable]
public class BaseSpaceship : BaseCelestialObject, ISpacecraft
{
    public float MaxSpeed { get; set; }
    public float Agility { get; set; }
    public List<IModule> Modules { get; set; } = new List<IModule>();

    public List<MicroWarpDrive> GetPropulsionModules()
    {
        return Modules.Where(module => module.Category == Category.Propulsion).Cast<MicroWarpDrive>().ToList();
    }

    public IModule GetModule(int moduleId)
    {
        return Modules.FirstOrDefault(module => module.Id == moduleId);
    }

    public void SetDirection(double direction) => Direction = direction;
}
