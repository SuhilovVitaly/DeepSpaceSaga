namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class ScanProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, Command command, int ticks = 1)
    {
        return new ScanProcessingHandler().Run(sessionContext, command);
    }

    public SessionContext Run(SessionContext sessionContext, Command command, int ticks = 1)
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
            new SpaceScannerActionEventProcessing().Execute(sessionContext, spacecraft, target, module);
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
