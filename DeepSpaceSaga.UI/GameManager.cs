namespace DeepSpaceSaga.UI;

public class GameManager : IDisposable
{
    public OuterSpace OuterSpace { get; set; } = new OuterSpace();
    public EventManager EventController { get; set; }

    public GameManager(EventManager eventManager)
    {
        EventController = eventManager;

        EventController.OnSelectCelestialObject += OuterSpace.EventController_OnSelectCelestialObject;
        EventController.OnUnselectCelestialObject += OuterSpace.EventController_OnUnselectCelestialObject;
        EventController.OnShowCelestialObject += OuterSpace.EventController_OnShowCelestialObject;
        EventController.OnHideCelestialObject += OuterSpace.EventController_OnHideCelestialObject;
    }    

    public ISpacecraft GetPlayerSpacecraft()
    {
        return GetSession().SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.OwnerId == 1) as ISpacecraft;
    }

    public CelestialMap GetCelestialMap()
    {
        return GetSession().SpaceMap;
    }

    public GameSession GetSession()
    {
        return EventController.GetSession();
    }

    public async Task ExecuteCommandAsync(Command command)
    {
        await EventController.ExecuteCommandAsync(command);
    }

    public void Dispose()
    {
        // Освобождение ресурсов
    }
}
