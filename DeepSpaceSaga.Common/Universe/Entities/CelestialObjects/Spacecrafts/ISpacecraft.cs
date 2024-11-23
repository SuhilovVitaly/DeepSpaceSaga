namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

public interface ISpacecraft : ICelestialObject
{
    float MaxSpeed { get; set; }
    float Agility { get; set; }
}
