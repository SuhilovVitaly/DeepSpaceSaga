namespace DeepSpaceSaga.Server.Calculation.GameActionEventProcessing;

internal class GameEventsProcessing
{
    public SessionContext Execute(SessionContext sessionContext, int ticks = 1)
    {
        foreach (var action in sessionContext.EventsSystem.Actions)
        {
            var gameEvent = action.Value;
            var spacecraft = sessionContext.Session.GetCelestialObject(gameEvent.CelestialObjectId) as ISpacecraft;
            var target = sessionContext.Session.GetCelestialObject(gameEvent.TargetObjectId);
            var module = spacecraft.GetModule(gameEvent.ModuleId);

            sessionContext = HandleGameEvent(sessionContext, spacecraft, target, module);

            sessionContext.EventsSystem.Actions.TryRemove(action.Key, out _);
        }

        return sessionContext;
    }

    private SessionContext HandleGameEvent(SessionContext sessionContext, ISpacecraft spacecraft, ICelestialObject target, IModule module)
    {
        switch (module.Category)
        {
            case Category.Weapon:
                break;
            case Category.Shield:
                break;
            case Category.Propulsion:
                break;
            case Category.Reactor:
                break;
            case Category.SpaceScanner:
                sessionContext = new SpaceScannerActionEventProcessing().Execute(sessionContext, spacecraft, target, module);
                break;
            case Category.DeepScanner:
                break;
            default:
                break;
        }

        return sessionContext;
    }
}
