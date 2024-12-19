namespace DeepSpaceSaga.Server.Infrastructure;

public class GameActionEvent
{
    public Command TriggerCommand { get; set; }
    public long CelestialObjectId { get; set; }
    public long TargetObjectId { get; set; }
    public long ModuleId { get; set; }
    public long Id { get; set; }
}
