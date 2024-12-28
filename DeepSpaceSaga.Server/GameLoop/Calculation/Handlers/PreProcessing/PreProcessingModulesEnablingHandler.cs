using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingModulesEnablingHandler : BaseHandler, ICalculationHandler
{
    public int Order => 4;

    public HandlerType Type => HandlerType.PreProcessing;

    public SessionContext Handle(SessionContext sessionContext)
    {
        if (sessionContext == null)
            throw new ArgumentNullException(nameof(sessionContext));

        foreach (Command command in sessionContext.EventsSystem.Commands.Where(x => x.Status == CommandStatus.PreProcess))
        {
            command.Status = CommandStatus.Process;

            var module = sessionContext.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);
            if (module == null)
            {
                continue;
            }

            if (command.IsOneTimeCommand == false)
            {
                module.Reload();
            }
        }

        return sessionContext;
    }
}
