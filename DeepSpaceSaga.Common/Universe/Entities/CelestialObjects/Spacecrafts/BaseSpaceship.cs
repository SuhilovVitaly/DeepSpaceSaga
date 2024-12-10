namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

[Serializable]
public class BaseSpaceship : BaseCelestialObject, ISpacecraft
{
    public float MaxSpeed { get; set; }
    public float Agility { get; set; }
    public List<IModule> Modules { get; set; } = new List<IModule>();

    public IModule GetModule(long moduleId)
    {
        return Modules.FirstOrDefault(module => module.Id == moduleId);
    }

    public void SetDirection(double direction) => Direction = direction;

    public List<IModule> GetModules(Category category)
    {
        return Modules.Where(module => module.Category == category).Cast<IModule>().ToList();
    }

    public void ChanheVelocity(double delta)
    {
        var updatedVelocity = Speed + delta;

        if(updatedVelocity > MaxSpeed)
        {
            updatedVelocity = MaxSpeed;
        }

        if(updatedVelocity < 0)
        {
            updatedVelocity = 0;
        }

        Speed = updatedVelocity;
    }
}
