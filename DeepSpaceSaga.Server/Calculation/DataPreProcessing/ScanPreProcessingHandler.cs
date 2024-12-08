namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ScanPreProcessingHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new ScanPreProcessingHandler().Run(session, eventsSystem, ticks);
    }
    // TODO: Move to General - Modules Pre Processing (For auto-run modules)
    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        var target = session.SpaceMap.GetCelestialObjects().Where(x=> x.IsPreScanned == false && x.OwnerId != 1 && x.IsPreScanned == false).FirstOrDefault();

        // Not target (not pres-scanned celestial objects) found
        if (target is null) return session;

        var spacecraft = session.GetPlayerSpaceShip();

        var scanner = spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        // Module not exist on spacecraft
        if (scanner is null) return session;

        // Module still not finished action result calculation
        if (scanner.IsCalculated == false) return session;

        // Target not in module range
        if (GeometryTools.Distance(target.GetLocation(), spacecraft.GetLocation()) > scanner.ScanRange) return session;

        // Module still works
        if(scanner.IsReloaded == false) return session;

        var scanCommand = new Command
        {
            Category = CommandCategory.Scan,
            CelestialObjectId = spacecraft.Id,
            ModuleId = scanner.Id,
            TargetCelestialObjectId = target.Id,
            Type = CommandTypes.PreScanCelestialObject,
            Status = CommandStatus.Process
        };

        eventsSystem.AddCommand(scanCommand);

        return session;
    }
}
