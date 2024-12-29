namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.PreProcessing;

public class PreProcessingModulesReloadingHandler : BaseHandler, ICalculationHandler
{
    public int Order => 3;

    public HandlerType Type => HandlerType.PreProcessing;

    public SessionContext Handle(SessionContext sessionContext)
    {
        var spacecraft = sessionContext.Session.GetPlayerSpaceShip();

        foreach (var moudle in spacecraft.Modules)
        {
            if (moudle.IsReloaded == false)
            {
                moudle.Reload(sessionContext.Settings.RatePerSecond());

                if (moudle.IsReloaded)
                {
                    sessionContext.EventsSystem.ProcessModuleResults(spacecraft, moudle);
                }
            }
        }

        return sessionContext;
    }
}
