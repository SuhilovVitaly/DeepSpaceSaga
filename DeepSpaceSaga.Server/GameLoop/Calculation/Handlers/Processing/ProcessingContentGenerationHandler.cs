namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

internal class ProcessingContentGenerationHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        foreach (ICommand command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.ContentGeneration))
        {
            context = Run(context, command);
        }
                    
        return context;
    }

    public IFlowContext Run(IFlowContext sessionContext, ICommand command)
    {
        var currentCelestialObject = command.CelestialObjectId > 0 ? sessionContext.Session.GetCelestialObject(command.CelestialObjectId) : null;

        switch (command.Type)
        {
            case CommandTypes.GenerateAsteroid:
                sessionContext.Metrics.Add(Metrics.ProcessingGenerateAsteroidCommand);
                currentCelestialObject = CelestialMaplestialObjectGeneration(sessionContext, command);
                break;
        }

        AddToJournal(sessionContext, command, currentCelestialObject);

        return sessionContext;
    }

    private ICelestialObject CelestialMaplestialObjectGeneration(IFlowContext sessionContext, ICommand command)
    {
        var scannerModule = sessionContext.Session.GetPlayerSpaceShip().GetModules(Category.SpaceScanner).FirstOrDefault() as IScanner;

        if (scannerModule is null) return null;

        var distance = sessionContext.Randomizer.GetInteger((int)(scannerModule.ScanRange - 10), (int)scannerModule.ScanRange);
        var direction = sessionContext.Randomizer.GetInteger(0, 359);
        var velocity = sessionContext.Randomizer.GetDouble(0.1, 10.0);

        var asteroidLocation = GeometryTools.Move(sessionContext.Session.GetPlayerSpaceShip().GetLocation(), distance, sessionContext.Randomizer.GetInteger(0, 359));

        var asteroid = AsteroidGenerator.CreateAsteroid(sessionContext.Randomizer, direction, asteroidLocation.X, asteroidLocation.Y, velocity, sessionContext.Randomizer.GenerateCelestialObjectName());

        sessionContext.Session.SpaceMap.Add(asteroid);

        return asteroid;
    }

    private void AddToJournal(IFlowContext sessionContext, ICommand command, ICelestialObject celestialObject)
    {
        sessionContext.Metrics.Add(Metrics.MessageAddedToJournal);

        sessionContext.Session.Logbook.Add(
            new EventMessage
            {
                Id = IdGenerator.GetNextId(),
                Type = EventType.DetectCelestialObject,
                Text = command.Type.GetDescription() + $" [{Math.Round(celestialObject.PositionX, 0)}:{Math.Round(celestialObject.PositionY, 0)}] {celestialObject.Direction}"
            });
    }
}

public static class ProcessingContentGenerationHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingContentGeneration(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingContentGenerationHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingContentGeneration(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingContentGenerationHandler>(result);
    }
}
