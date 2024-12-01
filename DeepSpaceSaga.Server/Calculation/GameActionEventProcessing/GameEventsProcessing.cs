namespace DeepSpaceSaga.Server.Calculation.GameActionEventProcessing;

internal class GameEventsProcessing
{
    public GameSession Execute(GameSession session, GameEventsSystem eventsSystem, int ticks = 1)
    {
        foreach (var action in eventsSystem.Actions)
        {
            var gameEvent = action.Value;
            var spacecraft = session.GetCelestialObject(gameEvent.CelestialObjectId) as ISpacecraft;
            var target = session.GetCelestialObject(gameEvent.TargetObjectId);
            var module = spacecraft.GetModule(gameEvent.ModuleId);

            session = HandleGameEvent(session, eventsSystem, spacecraft, target, module);

            eventsSystem.Actions.TryRemove(action.Key, out _);
        }

        return session;
    }

    private GameSession HandleGameEvent(GameSession session, GameEventsSystem eventsSystem, ISpacecraft spacecraft, ICelestialObject target, IModule module)
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
                session = new SpaceScannerActionEventProcessing().Execute(session, eventsSystem, spacecraft, target, module);
                break;
            case Category.DeepScanner:
                break;
            default:
                break;
        }

        return session;
    }
}
