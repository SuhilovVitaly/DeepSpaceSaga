namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

[Serializable]
public class BaseSpaceship : BaseCelestialObject, ISpacecraft
{
    public float MaxSpeed { get; set; }
    public float Agility { get; set; }
    public List<IModule> Modules { get; set; } = new List<IModule>();

    public IModule GetModule(int moduleId)
    {
        return Modules.FirstOrDefault(module => module.Id == moduleId);
    }

    public void SetDirection(double direction) => Direction = direction;

    public List<IModule> GetModules(Category category)
    {
        return Modules.Where(module => module.Category == category).Cast<IModule>().ToList();
    }
}
