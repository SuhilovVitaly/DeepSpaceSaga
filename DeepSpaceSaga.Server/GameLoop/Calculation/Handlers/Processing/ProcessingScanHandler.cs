﻿using DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingScanHandler : BaseHandler, ICalculationHandler
{
    public int Order => 5;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        if (context?.EventsSystem?.Commands == null)
            return context;

        foreach (Command command in context.EventsSystem.Commands.
            Where(x => x.Status == CommandStatus.Process && x.Category == CommandCategory.Scan))
        {
            context = Run(context, command);
        }

        return context;
    }

    public SessionContext Run(SessionContext sessionContext, Command command)
    {
        var currentCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        if (currentCelestialObject == null)
            throw new InvalidOperationException($"Celestial object not found with ID: {command.CelestialObjectId}");

        switch (command.Type)
        {
            case CommandTypes.PreScanCelestialObject:
                PreScanCelestialObject(sessionContext, currentCelestialObject, command);
                break;

            case CommandTypes.PreScanCelestialObjectFinished:
                PreScanCelestialObjectFinished(sessionContext, currentCelestialObject, command);
                break;
        }

        AddToJournal(sessionContext, command, currentCelestialObject);

        return sessionContext;
    }

    private void PreScanCelestialObjectFinished(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        if (celestialObject == null)
            throw new ArgumentNullException(nameof(celestialObject));

        var spacecraft = celestialObject.ToSpaceship();
        if (spacecraft == null)
            throw new InvalidOperationException($"Failed to convert celestial object to spacecraft: {celestialObject.Id}");

        var target = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);
        if (target == null)
            throw new InvalidOperationException($"Target celestial object not found with ID: {command.TargetCelestialObjectId}");

        var module = spacecraft.GetModule(command.ModuleId);        
        if (module == null)
            throw new InvalidOperationException($"Module not found with ID: {command.ModuleId}");

        target.IsPreScanned = true;

        module.IsCalculated = true;
    }

    private void PreScanCelestialObject(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        if (celestialObject == null)
            throw new ArgumentNullException(nameof(celestialObject));

        var spacecraft = celestialObject.ToSpaceship();
        if (spacecraft == null)
            throw new InvalidOperationException($"Failed to convert celestial object to spacecraft: {celestialObject.Id}");

        var module = spacecraft.GetModule(command.ModuleId);
        if (module == null)
            throw new InvalidOperationException($"Module not found with ID: {command.ModuleId}");

        module.TargetId = command.TargetCelestialObjectId;
        module.Reload();

        var target = sessionContext.Session.GetCelestialObject(module.TargetId);
        if (target == null)
            throw new InvalidOperationException($"Target celestial object not found with ID: {module.TargetId}");

        if (module.IsReloaded)
        {
            ActionScanFinished.Execute(sessionContext, spacecraft, target, module);
            command.Status = CommandStatus.PostProcess;
        }
    }

    private void AddToJournal(SessionContext sessionContext, Command command, ICelestialObject celestialObject)
    {
        if (sessionContext?.Session?.Logbook == null)
            throw new ArgumentNullException(nameof(sessionContext), "Session or Logbook is null");
        if (command == null)
            throw new ArgumentNullException(nameof(command));
        if (celestialObject == null)
            throw new ArgumentNullException(nameof(celestialObject));

        sessionContext.Session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = "Scan: " + command.Type.GetDescription()
            });
    }
}
