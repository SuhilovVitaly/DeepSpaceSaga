﻿namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

public interface ISpacecraft : ICelestialObject
{
    float MaxSpeed { get; set; }
    float Agility { get; set; }
    List<IModule> Modules { get; set; }
    IModule GetModule(long moduleId);
    List<IModule> GetModules(Category category); 
    void SetDirection(double direction);
    void ChangeVelocity(double delta);
}
