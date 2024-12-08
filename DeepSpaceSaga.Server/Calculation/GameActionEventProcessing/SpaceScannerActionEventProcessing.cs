namespace DeepSpaceSaga.Server.Calculation.GameActionEventProcessing;

internal class SpaceScannerActionEventProcessing
{
    public SessionContext Execute(SessionContext sessionContext, ISpacecraft spacecraft, ICelestialObject target, IModule module)
    {
        var command = new Command
        {
            Category = CommandCategory.Scan,
            CelestialObjectId = spacecraft.Id,
            ModuleId = module.Id,
            TargetCelestialObjectId = target.Id,
            Type = CommandTypes.PreScanCelestialObjectFinished,
            Status = CommandStatus.Process,
            IsOneTimeCommand = true,
        };

        sessionContext.EventsSystem.AddCommand(command);

        return sessionContext;
    }
}
