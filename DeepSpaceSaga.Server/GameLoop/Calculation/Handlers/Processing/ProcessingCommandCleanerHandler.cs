using DeepSpaceSaga.Common.Infrastructure.Commands;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingCommandCleanerHandler : BaseHandler, ICalculationHandler
{
    public int Order => int.MaxValue;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.GetCommandsByStatus(CommandStatus.Process))
        {
            var module = context.Session.GetPlayerSpaceShip().GetModule(command.ModuleId);

            if (module is null || module.IsCalculated || command.IsOneTimeCommand)
            {
                command.Status = CommandStatus.PostProcess;
            }
        }

        return context;
    }
}
