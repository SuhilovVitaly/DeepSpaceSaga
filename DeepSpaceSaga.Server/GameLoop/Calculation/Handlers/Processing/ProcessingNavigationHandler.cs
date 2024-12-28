using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingNavigationHandler : BaseHandler, ICalculationHandler
{
    public int Order => 4;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.
            Where(x => x.Status == CommandStatus.Process && x.Category == CommandCategory.Navigation))
        {
            context = Run(context, command);
        }

        return context;
    }

    internal SessionContext Run(SessionContext sessionContext, Command command)
    {
        sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommand);
        
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
            case CommandTypes.SyncDirectionWithTarget:
                sessionContext.Metrics.Add(Metrics.ProcessingNavigationSyncDirectionWithTargetCommand);
                SyncDirectionWithTarget(sessionContext, currentCelestialObject, command);
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

    private void SyncDirectionWithTarget(SessionContext sessionContext, ICelestialObject currentCelestialObject, Command command)
    {
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);
        var spacecraft = currentCelestialObject as ISpacecraft ??
            throw new InvalidOperationException($"Object {currentCelestialObject.Id} is not a spacecraft");
        var module = spacecraft.GetModule(command.ModuleId) ??
            throw new InvalidOperationException($"Module {command.ModuleId} not found");

        if (targetCelestialObject is null)
        {
            sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommandError);
            module.IsCalculated = true;
            return;
        }

        double directionBeforeManeuver = spacecraft.Direction;
        double directionAfterManeuver;

        if ((targetCelestialObject.Direction - spacecraft.Direction).To360Degrees() > 180)
        {
            directionAfterManeuver = directionBeforeManeuver - spacecraft.Agility;
        }
        else
        {
            directionAfterManeuver = directionBeforeManeuver + spacecraft.Agility;
        }

        spacecraft.SetDirection(directionAfterManeuver.To360Degrees());

        if (Math.Abs(targetCelestialObject.Direction - spacecraft.Direction) < spacecraft.Agility)
        {
            // Command execution finished
            command.Status = CommandStatus.PostProcess;
            spacecraft.Direction = targetCelestialObject.Direction;
            sessionContext.Metrics.Add(Metrics.ProcessingNavigationSyncDirectionWithTargetCommandFinished);
        }
    }

    private void SyncSpeedWithTarget(SessionContext sessionContext, ICelestialObject currentCelestialObject, Command command)
    {
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);
        var spacecraft = currentCelestialObject as ISpacecraft ?? 
            throw new InvalidOperationException($"Object {currentCelestialObject.Id} is not a spacecraft");
        var module = spacecraft.GetModule(command.ModuleId) ?? 
            throw new InvalidOperationException($"Module {command.ModuleId} not found");

        if (targetCelestialObject is null)
        {
            sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommandError);
            module.IsCalculated = true;
            return;
        }

        var speedDelta = Math.Abs(targetCelestialObject.Speed - spacecraft.Speed);

        if (speedDelta < spacecraft.Agility / 2)
        {
            spacecraft.Speed = targetCelestialObject.Speed;
            module.IsCalculated = true;
            return;
        }

        if (targetCelestialObject.Speed > spacecraft.Speed)
        {
            spacecraft.ChangeVelocity(spacecraft.Agility / 2);
        }
        else
        {
            spacecraft.ChangeVelocity(-(spacecraft.Agility / 2));
        }

        if (spacecraft.Speed >= spacecraft.MaxSpeed)
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

    private void RotateToTarget(SessionContext sessionContext, ICelestialObject currentCelestialObject, Command command)
    {
        var target = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        var spacecraft = sessionContext.Session.GetCelestialObject(command.CelestialObjectId) as ISpacecraft ??
            throw new InvalidOperationException($"Object {currentCelestialObject.Id} is not a spacecraft");

        double directionBeforeManeuver = spacecraft.Direction;
        var azimut = GeometryTools.Azimuth(target.GetLocation(), spacecraft.GetLocation());

        double directionAfterManeuver;
        if ((azimut - spacecraft.Direction).To360Degrees() > 180)
        {
            directionAfterManeuver = directionBeforeManeuver - spacecraft.Agility;
        }
        else
        {
            directionAfterManeuver = directionBeforeManeuver + spacecraft.Agility;
        }

        spacecraft.SetDirection(directionAfterManeuver.To360Degrees());

        azimut = GeometryTools.Azimuth(target.GetLocation(), spacecraft.GetLocation());         

        if (Math.Abs(azimut - spacecraft.Direction) < spacecraft.Agility)
        {
            // Command execution finished
            command.Status = CommandStatus.PostProcess;
            spacecraft.Direction = azimut;
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
