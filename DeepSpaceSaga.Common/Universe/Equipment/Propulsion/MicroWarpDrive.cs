namespace DeepSpaceSaga.Common.Universe.Equipment.Propulsion;

[Serializable]
public class MicroWarpDrive : AbstractModule, IModule, IPropulsionModule
{
    public Category Category { get; set; }
    public double ActivationCost { get; set; }
    public double Power { get; set; }

    public dynamic Acceleration()
    {
        var serverCommand = CreateServerCommand();

        serverCommand.TypeId = CommandTypes.Acceleration;

        return serverCommand;
    }

    public dynamic Braking()
    {
        var serverCommand = CreateServerCommand();

        serverCommand.TypeId = CommandTypes.StopShip;

        return serverCommand;
    }



    public dynamic TurnLeft()
    {
        var serverCommand = CreateServerCommand();

        serverCommand.TypeId = CommandTypes.TurnLeft;

        return serverCommand;
    }

    public dynamic TurnRight()
    {
        var serverCommand = CreateServerCommand();

        serverCommand.TypeId = CommandTypes.TurnRight;

        return serverCommand;
    }
}
