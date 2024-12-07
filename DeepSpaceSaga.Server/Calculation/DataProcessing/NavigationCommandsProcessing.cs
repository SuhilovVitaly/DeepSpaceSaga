
using DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class NavigationCommandsProcessing
{
    public void Execute(GameSession session, Command command)
    {
        var currentCelestialObject = session.GetCelestialObject(command.CelestialObjectId);

        switch (command.Type)
        {
            case CommandTypes.TurnLeft:
                TurnLeft(currentCelestialObject, command);
                break;
            case CommandTypes.TurnRight:
                TurnRight(currentCelestialObject, command);
                break;
            case CommandTypes.RotateToTarget:
                RotateToTarget(session, currentCelestialObject, command);
                break;
        }

        AddToJournal(session, command, currentCelestialObject);
    }

    private void RotateToTarget(GameSession session, ICelestialObject target, Command command)
    {
        var spacecraft = session.GetPlayerSpaceShip();

        var azimut = GeometryTools.Azimuth(target.GetLocation(), spacecraft.GetLocation());

        double directionBeforeManeuver = spacecraft.Direction;
        double directionAfterManeuver = 0;

        if (azimut > 180) 
        {
            // Turn Left
            directionAfterManeuver = (directionBeforeManeuver - spacecraft.Agility).To360Degrees();
        }
        else
        {
            // Turn Right
            directionAfterManeuver = (directionBeforeManeuver + spacecraft.Agility).To360Degrees();
        }

        spacecraft.SetDirection(directionAfterManeuver);

        if (Math.Abs(GeometryTools.Azimuth(target.GetLocation(), spacecraft.GetLocation())) < spacecraft.Agility)
        {
            // Command execution finished
        }
        
    }

    private void TurnLeft(ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);

        double directionBeforeManeuver = celestialObject.Direction;
        double directionAfterManeuver = (directionBeforeManeuver - spacecraft.Agility).To360Degrees();

        spacecraft.SetDirection(directionAfterManeuver);

        //module.Reload();
    }

    private void TurnRight(ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);

        double directionBeforeManeuver = celestialObject.Direction;
        double directionAfterManeuver = (directionBeforeManeuver + spacecraft.Agility).To360Degrees();

        spacecraft.SetDirection(directionAfterManeuver);

        //module.Reload();
    }

    private void AddToJournal(GameSession session, Command command, ICelestialObject celestialObject)
    {
        session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.NavigationManeuver,
                Text = "Navigation: " + command.Type.GetDescription() + $" {celestialObject.Direction}"
            });
    }
}
