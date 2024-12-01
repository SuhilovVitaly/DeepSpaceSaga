namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class ScanPreProcessing
{
    // TODO: Move to General - Modules Pre Processing (For auto-run modules)
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        var target = session.SpaceMap.GetCelestialObjects().Where(x=> x.IsPreScanned == false && x.OwnerId != 1).FirstOrDefault();

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
            Type = CommandTypes.PreScanCelestialObject
        };

        eventsSystem.AddCommand(scanCommand);

        return session;
    }
}
