namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

public class MiningProcessingHandler
{
    public static SessionContext Execute(SessionContext sessionContext, Command command)
    {
        return new MiningProcessingHandler().Run(sessionContext, command);
    }

    public SessionContext Run(SessionContext sessionContext, Command command)
    {
        switch (command.Type)
        {
            case CommandTypes.MiningOperationsHarvest:
                Harvest(sessionContext, command);
                break;
        }

        return sessionContext;
    }

    private void Harvest(SessionContext sessionContext, Command command)
    {
        var moduleCelestialObject = sessionContext.Session.GetCelestialObject(command.CelestialObjectId);
        var targetCelestialObject = sessionContext.Session.GetCelestialObject(command.TargetCelestialObjectId);
        var distance = GeometryTools.Distance(moduleCelestialObject.GetLocation(), targetCelestialObject.GetLocation());
        var module = moduleCelestialObject.ToSpaceship().GetModule(command.ModuleId) as IMiningLaser;

        if (distance > module.MiningRange)
        {
            // Cancel command bacause distance is to big
            command.Status = CommandStatus.PostProcess;
            return;
        }

        if (module.IsReloaded)
        {
            // Generate mining results

            command.Status = CommandStatus.PostProcess;
        }
    }
}
