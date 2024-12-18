namespace DeepSpaceSaga.Server.Calculation;

internal class PostProcessing
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new PostProcessing().Run(sessionContext);
    }

    internal SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        foreach (Command command in sessionContext.EventsSystem.Commands.Where(x => x.Status == CommandStatus.PostProcess))
        {
            // Invoke events for finished modules work
        }

        sessionContext.EventsSystem = RemovefinishedCommands(sessionContext.EventsSystem);

        return sessionContext;
    }

    internal GameEventsSystem RemovefinishedCommands(GameEventsSystem eventsSystem)
    {
        var filteredCommands = new ConcurrentQueue<Command>();

        foreach (var command in eventsSystem.Commands)
        {
            if (command.Status != CommandStatus.PostProcess)
            {
                filteredCommands.Enqueue(command);
            }
        }

        eventsSystem.Commands = filteredCommands;

        return eventsSystem;
    }
}
