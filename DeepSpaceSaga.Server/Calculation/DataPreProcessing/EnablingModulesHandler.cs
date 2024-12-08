namespace DeepSpaceSaga.Server.Calculation.DataPreProcessing;

internal class EnablingModulesHandler
{
    public static SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        return new EnablingModulesHandler().Run(sessionContext);
    }

    internal SessionContext Run(SessionContext sessionContext,  int ticks = 1)
    {
        foreach (Command command in sessionContext.EventsSystem.Commands.Where(x => x.Status == CommandStatus.PreProcess))
        {
            command.Status = CommandStatus.Process;

            var module = sessionContext.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if(command.IsOneTimeCommand == false)
            {
                module.Reload();
            }            
        }

        return sessionContext;
    }
}
