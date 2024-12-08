namespace DeepSpaceSaga.Server.Calculation;

internal class Processing
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new Processing().Run(session, eventsSystem, ticks);
    }

    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        session = CalculateLocationsHandler.Execute(session);

        foreach (Command command in eventsSystem.Commands.Where(x => x.Status == CommandStatus.Process))
        {
            switch (command.Category)
            {
                case CommandCategory.None:
                    break;
                case CommandCategory.Scan:
                    session = ScanProcessingHandler.Execute(session, eventsSystem, command);
                    break;
                case CommandCategory.Navigation:
                    session = NavigationProcessingHandler.Execute(session, command);
                    break;
                case CommandCategory.ContentGeneration:
                    session = ContentGenerationProcessingHandler.Execute(session, command);
                    break;
                case CommandCategory.ModuleActionFinished:
                    break;
                default:
                    break;
            }
            //new ContentGenerationProcessing().Execute(session, command);

            //new ScanProcessing().Execute(session, command);

            var module = session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if (module is null || module.IsCalculated || command.IsOneTimeCommand)
            {
                command.Status = CommandStatus.PostProcess;
            }
        }

        return session;
    }
}
