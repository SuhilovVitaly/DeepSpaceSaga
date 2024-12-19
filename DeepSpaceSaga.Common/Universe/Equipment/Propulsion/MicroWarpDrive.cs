namespace DeepSpaceSaga.Common.Universe.Equipment.Propulsion;


public class MicroWarpDrive : AbstractModule, IModule, IPropulsionModule
{
    public Category Category { get; set; }
    public double ActivationCost { get; set; }
    public double Power { get; set; }
}
