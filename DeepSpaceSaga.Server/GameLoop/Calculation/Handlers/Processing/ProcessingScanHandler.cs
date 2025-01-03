﻿namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingScanHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
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

    public IFlowContext Run(IFlowContext sessionContext, Command command)
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

    private void PreScanCelestialObjectFinished(IFlowContext sessionContext, ICelestialObject celestialObject, Command command)
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

    private void PreScanCelestialObject(IFlowContext sessionContext, ICelestialObject celestialObject, Command command)
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
        module.Reload(sessionContext.Settings.RatePerSecond());

        var target = sessionContext.Session.GetCelestialObject(module.TargetId);
        if (target == null)
            throw new InvalidOperationException($"Target celestial object not found with ID: {module.TargetId}");

        if (module.IsReloaded)
        {
            ActionScanFinished.Execute(sessionContext, spacecraft, target, module);
            command.Status = CommandStatus.PostProcess;
        }
    }

    private void AddToJournal(IFlowContext sessionContext, EventType type, string text)
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

public static class ProcessingScanHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingScan(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingScanHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingScan(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingScanHandler>(result);
    }
}