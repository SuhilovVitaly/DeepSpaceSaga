namespace DeepSpaceSaga.Common.Universe.Equipment.Propulsion;

public interface IPropulsionModule
{
    double Power { get; set; }

    dynamic Braking();
}
