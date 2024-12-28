using DeepSpaceSaga.Common.Infrastructure.Commands;

public static class CommandExtensions
{
    public static ConcurrentQueue<ICommand> GetCommandsByCategory(this ConcurrentQueue<ICommand> commands, CommandStatus status, CommandCategory category)
    {
        return new ConcurrentQueue<ICommand>(commands.Where(x => x.Status == status && x.Category == category));
    }

    public static ConcurrentQueue<ICommand> GetCommandsByStatus(this ConcurrentQueue<ICommand> commands, CommandStatus status)
    {
        return new ConcurrentQueue<ICommand>(commands.Where(x => x.Status == status));
    }
}