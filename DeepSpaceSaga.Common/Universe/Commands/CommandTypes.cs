namespace DeepSpaceSaga.Common.Universe.Commands;

public enum CommandTypes
{
    [Description("")]
    MoveForward = 200,
    [Description("Turn Left")]
    TurnLeft = 201,
    [Description("Turn Right")]
    TurnRight = 202,
    [Description("")]
    StopShip = 203,
    [Description("")]
    Acceleration = 204,
    [Description("")]
    Fire = 300,
    [Description("")]
    AlignTo = 100,
    [Description("")]
    Orbit = 110,
    [Description("")]
    Explosion = 800,
    [Description("")]
    ReloadWeapon = 900,
    [Description("")]
    Scanning = 1600,
    [Description("")]
    Shot = 2001,
    [Description("[Scanning] Pre scan celestial object")]
    PreScanCelestialObject = 3001,
    PreScanCelestialObjectFinished = 3002,
    [Description("Object detected")]
    GenerateAsteroid = 5001
}

public static class CommandTypesExtensions
{
    public static int ToInt(this CommandTypes command)
    {
        return (int)command;
    }
}