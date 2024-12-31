namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingMiningOperationsHandler : BaseHandler, ICalculationHandler
{
    public int Order => 3;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (Command command in context.EventsSystem.Commands.GetCommandsByCategory(CommandStatus.Process, CommandCategory.Mining))
        {
            context = Run(context, command);
        }

        return context;
    }

    public SessionContext Run(SessionContext sessionContext, Command command)
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

    private void DestroyAsteroid(SessionContext sessionContext, ICommand command)
    {
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        sessionContext.Session.SpaceMap.Remove(targetCelestialObject);

        AddToJournal(sessionContext, EventType.AsteroidHarvestDestroy, $"Asteroid '{targetCelestialObject.Name}' destroyed");
    }

    private void Result(SessionContext sessionContext, ICommand command)
    {
        var moduleCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);

        var module = moduleCelestialObject.ToSpaceship().GetModule(command.ModuleId) as IMiningLaser;

        GenerateAsteroidHarcestResult.Execute(sessionContext, command);

        command.Status = CommandStatus.PostProcess;

        AddToJournal(sessionContext, EventType.AsteroidHarvestShowResults, $"Asteroid '{targetCelestialObject.Name}' Harvest Results");
        
        DestroyAsteroid(sessionContext,
            CommandsFactory.CreateCommand(
                sessionContext.Randomizer, 
                CommandTypes.MiningOperationsDestroyAsteroid, 
                module, 
                targetCelestialObject, moduleCelestialObject
                ));
    }

    private void Harvest(SessionContext sessionContext, Command command)
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
