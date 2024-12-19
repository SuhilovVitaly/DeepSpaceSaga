public static class CommandExtensions
{
    public static ConcurrentQueue<Command> GetCommandsByCategory(this ConcurrentQueue<Command> commands, CommandStatus status, CommandCategory category)
    {
        return new ConcurrentQueue<Command>(commands.Where(x => x.Status == status && x.Category == category));
    }

    public static ConcurrentQueue<Command> GetCommandsByStatus(this ConcurrentQueue<Command> commands, CommandStatus status)
    {
        return new ConcurrentQueue<Command>(commands.Where(x => x.Status == status));
    }
}