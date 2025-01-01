﻿namespace DeepSpaceSaga.Common.Infrastructure.Commands;

public interface ICommand
{
    int Id { get; set; }
    CommandCategory Category { get; set; }
    CommandTypes Type { get; set; }
    CommandStatus Status { get; set; }
    ICommand? TriggerCommand { get; set; }
    long CelestialObjectId { get; set; }
    int MemberId { get; set; }
    long TargetCelestialObjectId { get; set; }
    int ModuleId { get; set; }
    bool IsOneTimeCommand { get; set; }
    bool IsUnique { get; set; }
}
