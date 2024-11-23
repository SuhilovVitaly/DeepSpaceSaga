﻿namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

[Serializable]
public class BaseCelestialObject
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Name { get; set; }
    public double Direction { get; set; }
    public double Speed { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
    public CelestialObjectTypes Types { get; set; } = CelestialObjectTypes.None;
}