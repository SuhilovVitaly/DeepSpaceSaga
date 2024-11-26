namespace DeepSpaceSaga.Common.Universe.Commands;

public class Command
{
    public CommandTypes Type { get; set; }
    public long CelestialObjectId { get; set; }
    public int MemberId { get; set; }
    public long TargetCelestialObjectId { get; set; }
    public int ModuleId {  get; set; }
}
