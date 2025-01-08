using DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Spacecrafts;

namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingItemsTransferHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    private static readonly ILog _logger = LogManager.GetLogger(typeof(ProcessingItemsTransferHandler));

    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        foreach (ICommand command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.CargoOperations))
        {
            context = Run(context, command);
        }

        return context;
    }

    public IFlowContext Run(IFlowContext sessionContext, ICommand command)
    {
        sessionContext.Metrics.Add(Metrics.ProcessingMiningCommand);

        switch (command.Type)
        {
            case CommandTypes.CargoOperationsTransfer:
                TransferItemBetweenContainers(sessionContext, command);
                break;
        }

        return sessionContext;
    }

    private void TransferItemBetweenContainers(IFlowContext sessionContext, ICommand command)
    {
        var cargoOperationCommand = command as CargoOperationsCommand;

        if(cargoOperationCommand is null)
        {
            _logger.Error($"Command not is correct type (CommandTypes.CargoOperationsTransfer).");
            return;
        }

        var spacecraft = sessionContext.Session.GetCelestialObject(cargoOperationCommand.CelestialObjectId) as ISpacecraft;
        var inputObject = sessionContext.Session.GetCelestialObject(cargoOperationCommand.TargetCelestialObjectId) as IAsteroid;

        var outputCargo = spacecraft.GetModule(cargoOperationCommand.ModuleId) as ICargoContainer;
        var inputCargo = inputObject.CoreContainer;

        var item = inputCargo.GetItemById(cargoOperationCommand.InputItemId);

        inputCargo.RemoveItem(item);
        outputCargo.AddItem(item);

        command.Status = CommandStatus.PostProcess;
    }
}

public static class ProcessingItemsTransferHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingItemsTransfer(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingItemsTransferHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingItemsTransfer(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingItemsTransferHandler>(result);
    }
}
