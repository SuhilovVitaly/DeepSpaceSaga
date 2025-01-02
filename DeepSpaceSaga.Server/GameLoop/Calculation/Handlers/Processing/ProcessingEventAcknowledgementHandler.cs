namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingEventAcknowledgementHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.
            Where(x => x.Status == CommandStatus.Process && x.Category == CommandCategory.EventAcknowledgement))
        {
            context = Run(context, command);
        }

        return context;
    }

    internal IFlowContext Run(IFlowContext sessionContext, ICommand command)
    {
        sessionContext.Metrics.Add(Metrics.ProcessingNavigationCommand);
        
        var currentCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);

        var journalMessage = $"Confirmation of receiving command {command.Id} ";

        switch (command.Type)
        {
            case CommandTypes.EventReceipt:
                sessionContext.Metrics.Add(Metrics.ProcessingEventAcknowledgementEventReceiptCommand);
                EventReceipt(sessionContext, currentCelestialObject, command);
                break;
        }

        AddToJournal(sessionContext, EventType.EventAcknowledgement, journalMessage);

        return sessionContext;
    }     

    private void EventReceipt(IFlowContext sessionContext, ICelestialObject currentCelestialObject, ICommand command)
    {
        command.Status = CommandStatus.PostProcess;
    }

    private void AddToJournal(IFlowContext sessionContext, EventType type, string text)
    {
        if (sessionContext?.Session?.Logbook == null)
            throw new ArgumentNullException(nameof(sessionContext), "Session or Logbook is null");


        sessionContext.Session.Logbook.Add(new EventMessage
        {
            Id = IdGenerator.GetNextId(),
            Type = type,
            Text = text
        });
    }
}

public static class ProcessingEventAcknowledgementHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingEventAcknowledgement(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingEventAcknowledgementHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingEventAcknowledgement(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingEventAcknowledgementHandler>(result);
    }
}
