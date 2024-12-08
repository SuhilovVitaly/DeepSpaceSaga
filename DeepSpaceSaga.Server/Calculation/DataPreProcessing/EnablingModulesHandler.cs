namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class EnablingModulesHandler
{
    public static GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        return new EnablingModulesHandler().Run(session, eventsSystem);
    }

    internal GameSession Run(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        foreach (Command command in eventsSystem.Commands.Where(x => x.Status == CommandStatus.PreProcess))
        {
            command.Status = CommandStatus.Process;

            var module = session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if(command.IsOneTimeCommand == false)
            {
                module.Reload();
            }            
        }

        return session;
    }
}
