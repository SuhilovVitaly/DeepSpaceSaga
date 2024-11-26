namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class NavigationCommandsProcessing
{
    public void Execute(GameSession session, Command command)
    {
        var currentCelestialObject = session.GetCelestialObject(command.CelestialObjectId);

        switch (command.Type)
        {
            case Common.Universe.Commands.CommandTypes.TurnLeft:
                TurnLeft(currentCelestialObject, command);
                break;
            case Common.Universe.Commands.CommandTypes.TurnRight:
                TurnRight(currentCelestialObject, command);
                break;
        }
    }

    private void TurnLeft(ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);

        double directionBeforeManeuver = celestialObject.Direction;
        double directionAfterManeuver = (directionBeforeManeuver - 5).To360Degrees();

        spacecraft.SetDirection(directionAfterManeuver);

        module.Reload();
    }

    private void TurnRight(ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);

        double directionBeforeManeuver = celestialObject.Direction;
        double directionAfterManeuver = (directionBeforeManeuver + 5).To360Degrees();

        spacecraft.SetDirection(directionAfterManeuver);

        module.Reload();
    }
}
