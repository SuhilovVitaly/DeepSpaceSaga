namespace DeepSpaceSaga.Server.Calculation;

internal class Processing
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new Processing().Run(sessionContext, ticks);
    }

    internal SessionContext Run(SessionContext sessionContext, int ticks = 1)
    {
        sessionContext = CalculateLocationsHandler.Execute(sessionContext);

        foreach (Command command in sessionContext.EventsSystem.Commands.Where(x => x.Status == CommandStatus.Process))
        {
            switch (command.Category)
            {
                case CommandCategory.None:
                    break;
                case CommandCategory.Scan:
                    sessionContext = ScanProcessingHandler.Execute(sessionContext, command);
                    break;
                case CommandCategory.Navigation:
                    sessionContext = NavigationProcessingHandler.Execute(sessionContext, command);
                    break;
                case CommandCategory.ContentGeneration:
                    sessionContext = ContentGenerationProcessingHandler.Execute(sessionContext, command);
                    break;
                case CommandCategory.ModuleActionFinished:
                    break;
                default:
                    break;
            }

            var module = sessionContext.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if (module is null || module.IsCalculated || command.IsOneTimeCommand)
            {
                command.Status = CommandStatus.PostProcess;
            }
        }

        return sessionContext;
    }
}
