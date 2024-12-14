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
            case CommandTypes.SyncSpeedWithTarget:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationSyncSpeedWithTargetCommand);
                SyncSpeedWithTarget(sessionContext, currentCelestialObject, command);
                break;
            case CommandTypes.RotateToTarget:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationRotateToTargetCommand);
                RotateToTarget(sessionContext, currentCelestialObject, command);
                break;
            case CommandTypes.StopShip:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationStopShipCommand);
                FullStop(sessionContext, currentCelestialObject, command);
                break;
            case CommandTypes.FullSpeed:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationFullSpeedCommand);
                FullSpeed(sessionContext, currentCelestialObject, command);
                break;
        }

        AddToJournal(sessionContext, command, currentCelestialObject);

        return sessionContext;
    }

    private void SyncSpeedWithTarget(SessionContext sessionContext, ICelestialObject currentCelestialObject, Command command)
    {
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);
        var spacecraft = currentCelestialObject as ISpacecraft;
        var module = spacecraft.GetModule(command.ModuleId);

        if(targetCelestialObject is null)
        {
            sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommandError);
            module.IsCalculated = true;
            return;
        }

        var speedDelta = Math.Abs(targetCelestialObject.Speed - spacecraft.Speed);

        if(speedDelta < spacecraft.Agility / 2)
        {
            spacecraft.Speed = targetCelestialObject.Speed;
            module.IsCalculated = true;
            return;
        }

        if(targetCelestialObject.Speed > spacecraft.Speed)
        {
            spacecraft.ChangeVelocity(spacecraft.Agility / 2);
        }
        else
        {
            spacecraft.ChangeVelocity(- (spacecraft.Agility / 2));
        }

        if(spacecraft.Speed >= spacecraft.MaxSpeed)
        {
            spacecraft.Speed = spacecraft.MaxSpeed;
            module.IsCalculated = true;
        }
    }

    private void FullSpeed(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        spacecraft.ChangeVelocity(0.5);
        var module = spacecraft.GetModule(command.ModuleId);

        module.IsCalculated = spacecraft.Speed >= spacecraft.MaxSpeed;
    }

    private void FullStop(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        spacecraft.ChangeVelocity(-0.5);
        var module = spacecraft.GetModule(command.ModuleId);

        module.IsCalculated = spacecraft.Speed <= 0;
    }

    private void DecreaseShipSpeed(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        celestialObject.ToSpaceship().ChangeVelocity(-0.5);
    }

    private void IncreaseShipSpeed(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        celestialObject.ToSpaceship().ChangeVelocity(0.5);
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
