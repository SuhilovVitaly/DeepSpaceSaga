namespace DeepSpaceSaga.Common.Universe.Commands;

public interface ICommand
{
    int Id { get; set; }
    CommandCategory Category { get; set; }
    CommandTypes Type { get; set; }
    CommandStatus Status { get; set; }
    long CelestialObjectId { get; set; }
    int MemberId { get; set; }
    long TargetCelestialObjectId { get; set; }
    int ModuleId { get; set; }
    bool IsOneTimeCommand { get; set; }
    bool IsUnique { get; set; }
}
