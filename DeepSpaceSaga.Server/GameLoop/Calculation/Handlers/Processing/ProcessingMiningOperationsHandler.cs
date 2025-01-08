namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingMiningOperationsHandler(IFlowContext context) : FlowStepBase<IFlowContext, IFlowContext>(context)
{
    public override IFlowContext Execute(IFlowContext flowContext)
    {
        flowContext = Handle(flowContext);
        return flowContext;
    }

    public IFlowContext Handle(IFlowContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.Mining))
        {
            context = Run(context, command);
        }

        return context;
    }

    public IFlowContext Run(IFlowContext sessionContext, Command command)
    {
        sessionContext.Metrics.Add(Metrics.ProcessingMiningCommand);

        switch (command.Type)
        {
            case CommandTypes.MiningOperationsHarvest:
                Harvest(sessionContext, command);
                break;
            case CommandTypes.MiningOperationsResult:
                Result(sessionContext, command);
                break;
            case CommandTypes.MiningOperationsDestroyAsteroid:
                DestroyAsteroid(sessionContext, command);
                break;
        }

        return sessionContext;
    }

    private void DestroyAsteroid(IFlowContext sessionContext, ICommand command)
    {
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        sessionContext.Session.SpaceMap.Remove(targetCelestialObject);

        AddToJournal(sessionContext, EventType.AsteroidHarvestDestroy, $"Asteroid '{targetCelestialObject.Name}' destroyed");
    }

    private void Result(IFlowContext sessionContext, ICommand command)
    {
        var spacecraft = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        var asteroid = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId) as IAsteroid;

        var module = spacecraft.ToSpaceship().GetModule(command.ModuleId) as IMiningLaser;        

        command.Status = CommandStatus.PostProcess;

        asteroid?.Drill();        

        if (asteroid.RemainingDrillAttempts <= 0)
        {
            DestroyAsteroid(sessionContext,
                CommandsFactory.CreateCommand(
                    sessionContext.Randomizer,
                    CommandTypes.MiningOperationsDestroyAsteroid,
                    module,
                    asteroid, spacecraft
                    ));

            AddToJournal(sessionContext, EventType.AsteroidHarvestDestroy, $"Asteroid '{asteroid?.Name}' destroyed");
        }
        else
        {
            asteroid.CoreContainer.AddItems(GenerateAsteroidHarcestResult.Execute(sessionContext, command));

            AddToJournal(sessionContext, EventType.AsteroidHarvestShowResults, $"Asteroid '{asteroid?.Name}' Harvest Results");

            var uiEvent = EventsFactory.CreateEvent(sessionContext.Randomizer, command, module, asteroid, spacecraft);
            sessionContext.Session.Events.Add(uiEvent);
        }
    }

    private void Harvest(IFlowContext sessionContext, Command command)
    {
        var moduleCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        if(targetCelestialObject is null) return;

        var distance = GeometryTools.Distance(moduleCelestialObject.GetLocation(), targetCelestialObject.GetLocation());

        var module = moduleCelestialObject.ToSpaceship().GetModule(command.ModuleId) as IMiningLaser;

        if (distance > module.MiningRange)
        {
            AddToJournal(sessionContext, EventType.AsteroidHarvestCancelled, $"Asteroid '{targetCelestialObject.Name}' Harvest Cancelled");
            sessionContext.Metrics.Add(Metrics.ProcessingMiningCommandCancelled);
            // Cancel command bacause distance is to big
            command.Status = CommandStatus.PostProcess;
            return;
        }

        if (module.IsReloaded)
        {
            // Generate mining results
            AddToJournal(sessionContext, EventType.AsteroidHarvestFinished, $"Asteroid '{targetCelestialObject.Name}' Harvest Finished");
            sessionContext.Metrics.Add(Metrics.ProcessingMiningCommandFinished);
            command.Status = CommandStatus.PostProcess;
            sessionContext.EventsSystem.GenerateCommand(CommandTypes.MiningOperationsResult, module, targetCelestialObject, moduleCelestialObject);
        }
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

public static class ProcessingMiningOperationsHandlerFlowExtensions
{
    public static IFlowStep<IFlowContext, IFlowContext> ProcessingMiningOperations(this IFlowContext context)
    {
        var factory = FlowStepFactory.Instance;
        return factory.CreateStep<ProcessingMiningOperationsHandler>(context);
    }

    public static IFlowStep<IFlowContext, IFlowContext> ProcessingMiningOperations(this IFlowStep<IFlowContext, IFlowContext> step)
    {
        var factory = FlowStepFactory.Instance;
        var result = step.Execute(step.FlowContext);
        return factory.CreateStep<ProcessingMiningOperationsHandler>(result);
    }
}