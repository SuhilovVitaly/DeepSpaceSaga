namespace DeepSpaceSaga.Server.Calculation;

internal class PostProcessing
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new PostProcessing().Run(session, eventsSystem);
    }

    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        foreach (Command command in eventsSystem.Commands.Where(x => x.Status == CommandStatus.PostProcess))
        {
            // Invoke events for finished modules work
        }

        eventsSystem = RemovefinishedCommands(eventsSystem);

        return session;
    }

    internal GameEventsSystem RemovefinishedCommands(GameEventsSystem eventsSystem)
    {
        var filteredCommands = new ConcurrentBag<Command>();

        foreach (var command in eventsSystem.Commands)
        {
            if (command.Status != CommandStatus.PostProcess)
            {
                filteredCommands.Add(command);
            }
        }

        eventsSystem.Commands = filteredCommands;

        return eventsSystem;
    }
}
