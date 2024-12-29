namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class PreProcessingScanHandler : BaseHandler, ICalculationHandler
{
    public int Order => 2;

    public HandlerType Type => HandlerType.PreProcessing;

    public SessionContext Handle(SessionContext sessionContext)
    {
        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        var scanner = spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        foreach (Command command in sessionContext.EventsSystem.Commands.
            Where(x => x.Status == CommandStatus.PreProcess && x.Category == CommandCategory.Scan))
        {
            switch (command.Type)
            {
                case CommandTypes.PreScanCelestialObjectFinished:
                    command.Status = CommandStatus.Process;
                    break;
            }
        }

        var target = sessionContext.Session.SpaceMap.GetCelestialObjects()
            .Where(x=> 
                x.IsPreScanned == false 
                && 
                x.OwnerId != 1 
                && 
                x.IsPreScanned == false 
                && GeometryTools.Distance(x.GetLocation(), spacecraft.GetLocation()) < scanner.ScanRange
                )
            .FirstOrDefault();

        // Not target (not pres-scanned celestial objects) found
        if (target is null) return sessionContext;        

        // Module not exist on spacecraft
        if (scanner is null) return sessionContext;

        // Module still not finished action result calculation
        if (scanner.IsCalculated == false) return sessionContext;

        // Target not in module range
        if (GeometryTools.Distance(target.GetLocation(), spacecraft.GetLocation()) > scanner.ScanRange) return sessionContext;

        // Module still works
        if(scanner.IsReloaded == false) return sessionContext;

        var scanCommand = new Command
        {
            Category = CommandCategory.Scan,
            CelestialObjectId = spacecraft.Id,
            ModuleId = scanner.Id,
            TargetCelestialObjectId = target.Id,
            IsUnique = false,
            Type = CommandTypes.PreScanCelestialObject,
            Status = CommandStatus.Process
        };

        scanner.Execute();

        sessionContext.EventsSystem.AddCommand(scanCommand);

        return sessionContext;
    }    
}
