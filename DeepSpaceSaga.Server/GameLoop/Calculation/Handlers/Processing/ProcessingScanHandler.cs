using DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingScanHandler : BaseHandler, ICalculationHandler
{
    public int Order => 5;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
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
        var spacecraft = celestialObject.ToSpaceship();
        var target = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        target.IsPreScanned = true;

        var module = spacecraft.GetModule(command.ModuleId);
        module.IsCalculated = true;
    }

    private void PreScanCelestialObject(SessionContext sessionContext, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();

        var module = spacecraft.GetModule(command.ModuleId);
        module.TargetId = command.TargetCelestialObjectId;
        module.Reload();

        var target = sessionContext.Session.GetCelestialObject(module.TargetId);

        if (module.IsReloaded)
        {
            ActionScanFinished.Execute(sessionContext, spacecraft, target, module);
            command.Status = CommandStatus.PostProcess;
        }
    }

    private void AddToJournal(SessionContext sessionContext, Command command, ICelestialObject celestialObject)
    {
        sessionContext.Session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = "Scan: " + command.Type.GetDescription()
            });
    }
}
