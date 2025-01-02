namespace DeepSpaceSaga.Server.GameLoop.Calculation.Actions;

public class ActionScanFinished
{
    public static IFlowContext Execute(IFlowContext sessionContext, ISpacecraft spacecraft, ICelestialObject target, IModule module)
    {
        var command = new Command
        {
            Category = CommandCategory.Scan,
            CelestialObjectId = spacecraft.Id,
            ModuleId = module.Id,
            TargetCelestialObjectId = target.Id,
            Type = CommandTypes.PreScanCelestialObjectFinished,
            Status = CommandStatus.PreProcess,
            IsOneTimeCommand = true,
        };

        sessionContext.EventsSystem.AddCommand(command);

        return sessionContext;
    }
}
