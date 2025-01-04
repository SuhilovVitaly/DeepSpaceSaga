namespace DeepSpaceSaga.Common.Infrastructure.Events;

public class GameActionEvent
{
    public ICommand? TriggerCommand { get; set; }
    public long? CelestialObjectId { get; set; }
    public long? TargetObjectId { get; set; }
    public long? ModuleId { get; set; }
    public long Id { get; set; }
    public long CalculationTurnId { get; set; }
}
