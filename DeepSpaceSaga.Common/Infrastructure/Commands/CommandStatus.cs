namespace DeepSpaceSaga.Common.Infrastructure.Commands;

public enum CommandStatus
{
    None,
    PreProcess,
    Process,
    PostProcess,
    Finalizing
}
