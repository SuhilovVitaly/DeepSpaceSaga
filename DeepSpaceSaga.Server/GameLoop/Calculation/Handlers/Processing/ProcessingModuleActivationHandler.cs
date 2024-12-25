namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingModuleActivationHandler : BaseHandler, ICalculationHandler
{
    public int Order => int.MaxValue - 100;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        var spacecraft = context.Session.GetPlayerSpaceShip();

        foreach (var module in spacecraft.Modules)
        {
            if(context.EventsSystem.Commands.Where(x=>x.ModuleId == module.Id && x.CelestialObjectId == spacecraft.Id).Any())
            {
                module.IsActive = true;

                if(module.Category == Category.MiningLaser)
                {
                    var x = "";
                }
            }
        }

        return context;
    }
}
