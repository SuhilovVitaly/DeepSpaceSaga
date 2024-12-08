using DeepSpaceSaga.Server.Calculation.GameActionEventProcessing;

namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ScanProcessingHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, Command command, int ticks = 1)
    {
        return new ScanProcessingHandler().Run(session, eventsSystem, command);
    }

    public GameSession Run(GameSession session, GameEventsSystem eventsSystem, Command command, int ticks = 1)
    {
        var currentCelestialObject = session.GetCelestialObject(command.CelestialObjectId);

        switch (command.Type)
        {
            case CommandTypes.PreScanCelestialObject:
                PreScanCelestialObject(session, eventsSystem, currentCelestialObject, command);
                break;

            case CommandTypes.PreScanCelestialObjectFinished:
                PreScanCelestialObjectFinished(session, eventsSystem, currentCelestialObject, command);
                break;
        }

        AddToJournal(session, eventsSystem, command, currentCelestialObject);

        return session;
    }

    private void PreScanCelestialObjectFinished(GameSession session, GameEventsSystem eventsSystem, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();
        var target = session.GetCelestialObject(command.TargetCelestialObjectId);

        target.IsPreScanned = true;

        var module = spacecraft.GetModule(command.ModuleId);
        module.IsCalculated = true;
    }

    private void PreScanCelestialObject(GameSession session, GameEventsSystem eventsSystem, ICelestialObject celestialObject, Command command)
    {
        var spacecraft = celestialObject.ToSpaceship();
        

        var module = spacecraft.GetModule(command.ModuleId);
        module.TargetId = command.TargetCelestialObjectId;        
        module.Reload();

        var target = session.GetCelestialObject(module.TargetId);

        if (module.IsReloaded)
        {
            new SpaceScannerActionEventProcessing().Execute(session, eventsSystem, spacecraft, target, module);
            command.Status = CommandStatus.PostProcess;
        }
    }

    private void AddToJournal(GameSession session, GameEventsSystem eventsSystem, Command command, ICelestialObject celestialObject)
    {
        session.Logbook.Add(
            new Common.Universe.Audit.EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = Common.Universe.Audit.EventType.DetectCelestialObject,
                Text = "Scan: " + command.Type.GetDescription() 
            });
    }
}
