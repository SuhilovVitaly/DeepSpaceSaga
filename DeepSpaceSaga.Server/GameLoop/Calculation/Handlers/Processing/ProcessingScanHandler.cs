using DeepSpaceSaga.Common.Infrastructure.Commands;
using DeepSpaceSaga.Common.Universe.Audit;
using DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingScanHandler : BaseHandler, ICalculationHandler
{
    public int Order => 5;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(context.EventsSystem);
        ArgumentNullException.ThrowIfNull(context.EventsSystem.Commands);

        foreach (Command command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.Scan))
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

        AddToJournal(sessionContext, EventType.CelestialObjectIdentified, $"Celestial Object '{target.Name}' Identified");
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

    private void AddToJournal(SessionContext sessionContext, EventType type, string text)
    {
        if (sessionContext?.Session?.Logbook == null)
            throw new ArgumentNullException(nameof(sessionContext), "Session or Logbook is null");


        sessionContext.Session.Logbook.Add(new EventMessage
        {
            Id = IdGenerator.GetNextId(),
            Type = type,
            Text = text
        });
    }
}
