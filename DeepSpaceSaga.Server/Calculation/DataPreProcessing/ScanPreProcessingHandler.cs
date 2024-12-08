namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ScanPreProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new ScanPreProcessingHandler().Run(sessionContext, ticks);
    }
    // TODO: Move to General - Modules Pre Processing (For auto-run modules)
    internal SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        var target = sessionContext.Session.SpaceMap.GetCelestialObjects().Where(x=> x.IsPreScanned == false && x.OwnerId != 1 && x.IsPreScanned == false).FirstOrDefault();

        // Not target (not pres-scanned celestial objects) found
        if (target is null) return sessionContext;

        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        var scanner = spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

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
            Type = CommandTypes.PreScanCelestialObject,
            Status = CommandStatus.Process
        };

        sessionContext.EventsSystem.AddCommand(scanCommand);

        return sessionContext;
    }
}
