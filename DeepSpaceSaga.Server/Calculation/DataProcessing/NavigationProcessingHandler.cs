namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class NavigationProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, Command command)
    {
        sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommand);
        return new NavigationProcessingHandler().Run(sessionContext, command);
    }
    internal SessionContext Run(SessionContext sessionContext, Command command)
    {
        var currentCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);

        switch (command.Type)
        {
            case CommandTypes.IncreaseShipSpeed:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationIncreaseShipSpeedCommand);
                IncreaseShipSpeed(sessionContext, currentCelestialObject, command);
                break;
            case CommandTypes.DecreaseShipSpeed:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationDecreaseShipSpeedCommand);
                DecreaseShipSpeed(sessionContext, currentCelestialObject, command);
                break;
            case CommandTypes.TurnLeft:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationTurnLeftCommand);
                TurnLeft(currentCelestialObject, command);
                break;
            case CommandTypes.TurnRight:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationTurnRightCommand);
                TurnRight(currentCelestialObject, command);
                break;
            case CommandTypes.RotateToTarget:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationRotateToTargetCommand);
                RotateToTarget(sessionContext, currentCelestialObject, command);
                break;
        }

        AddToJournal(sessionContext, command, currentCelestialObject);

        return sessionContext;
    }

    private void DecreaseShipSpeed(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        celestialObject.ToSpaceship().ChanheVelocity(-0.5);
    }

    private void IncreaseShipSpeed(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        celestialObject.ToSpaceship().ChanheVelocity(0.5);
    }

    private void RotateToTarget(SessionContext sessionContext, ICelestialObject target, Command command)
    {
        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

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

    private void AddToJournal(SessionContext sessionContext, Command command, ICelestialObject celestialObject)
    {
        sessionContext.Metrics.Add(Metrics.MessageAddedToJournal);

        sessionContext.Session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.NavigationManeuver,
                Text = "Navigation: " + command.Type.GetDescription() + $" {celestialObject.Direction}"
            });
    }
}
