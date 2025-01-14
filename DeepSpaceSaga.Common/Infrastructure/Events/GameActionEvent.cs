namespace DeepSpaceSaga.Common.Infrastructure.Events;

public class GameActionEvent: IGameActionEvent
{
    public ICommand? TriggerCommand { get; set; }
    public long? CelestialObjectId { get; set; }
    public long? TargetObjectId { get; set; }
    public long? ModuleId { get; set; }
    public long Id { get; set; }
    public long CalculationTurnId { get; set; }
}

public interface IGameActionEvent
{
    ICommand? TriggerCommand { get; set; }
    long? CelestialObjectId { get; set; }
    long? TargetObjectId { get; set; }
    long? ModuleId { get; set; }
    long Id { get; set; }
    long CalculationTurnId { get; set; }
}
