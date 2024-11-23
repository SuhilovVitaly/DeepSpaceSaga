namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

[Serializable]
public class BaseSpaceship : BaseCelestialObject, ISpacecraft
{
    public float MaxSpeed { get; set; }
    public float Agility { get; set; }
}
