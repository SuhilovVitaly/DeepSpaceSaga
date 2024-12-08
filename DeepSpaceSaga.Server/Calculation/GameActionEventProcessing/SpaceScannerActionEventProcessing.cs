namespace DeepSpaceSaga.Server.Calculation.GameActionEventProcessing;

internal class SpaceScannerActionEventProcessing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, ISpacecraft spacecraft, ICelestialObject target, IModule module)
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

        eventsSystem.AddCommand(command);

        return session;
    }
}
