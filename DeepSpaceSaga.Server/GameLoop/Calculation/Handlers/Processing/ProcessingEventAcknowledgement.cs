namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingEventAcknowledgement : BaseHandler, ICalculationHandler
{
    public int Order => 16;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.
            Where(x => x.Status == CommandStatus.Process && x.Category == CommandCategory.EventAcknowledgement))
        {
            context = Run(context, command);
        }

        return context;
    }

    internal SessionContext Run(SessionContext sessionContext, ICommand command)
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

    private void EventReceipt(SessionContext sessionContext, ICelestialObject currentCelestialObject, ICommand command)
    {
        command.Status = CommandStatus.PostProcess;
    }

    private void AddToJournal(SessionContext sessionContext, EventType type, string text)
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
