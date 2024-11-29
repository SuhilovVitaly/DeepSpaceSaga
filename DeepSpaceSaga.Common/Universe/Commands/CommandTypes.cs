namespace DeepSpaceSaga.Common.Universe.Commands;

public enum CommandTypes
{
    MoveForward = 200,
    TurnLeft = 201,
    TurnRight = 202,
    StopShip = 203,
    Acceleration = 204,
    Fire = 300,
    AlignTo = 100,
    Orbit = 110,
    Explosion = 800,
    ReloadWeapon = 900,
    Scanning = 1600,
    Shot = 2001,
    GenerateAsteroid = 5001
}

public static class CommandTypesExtensions
{
    public static int ToInt(this CommandTypes command)
    {
        return (int)command;
    }
}