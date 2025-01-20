namespace DeepSpaceSaga.UI;

public class GameManager : IGameManager
{
    public IOuterSpace SpaceEnvironment { get; set; }
    public ISaveLoadManager SaveLoadSystem { get; set; }
    public IEventManager Events { get; set; }
    public IScreenManager Screens { get; set; }    

    private bool disposed;

    public GameManager(IEventManager eventManager, IScreenManager screenManager, ISaveLoadManager saveLoadManager, IOuterSpace outerSpace)
    {
        Events = eventManager;
        Screens = screenManager;
        SaveLoadSystem = saveLoadManager;
        SpaceEnvironment = outerSpace;

        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        Events.OnSelectCelestialObject += SpaceEnvironment.EventController_OnSelectCelestialObject;
        Events.OnUnselectCelestialObject += SpaceEnvironment.EventController_OnUnselectCelestialObject;
        Events.OnShowCelestialObject += SpaceEnvironment.EventController_OnShowCelestialObject;
        Events.OnHideCelestialObject += SpaceEnvironment.EventController_OnHideCelestialObject;        
    }

    public ISpacecraft GetPlayerSpacecraft()
    {
        return GetSession().SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.OwnerId == 1) as ISpacecraft;
    }

    public ICelestialObject GetCelestialObject(int id)
    {
        return GetSession().SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.Id == id);
    }

    public CelestialMap GetCelestialMap()
    {
        return GetSession().SpaceMap;
    }

    public GameSessionDTO GetSession()
    {
        return Events.GetSession();
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await Events.ExecuteCommandAsync(command);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Events.OnSelectCelestialObject -= SpaceEnvironment.EventController_OnSelectCelestialObject;
                Events.OnUnselectCelestialObject -= SpaceEnvironment.EventController_OnUnselectCelestialObject;
                Events.OnShowCelestialObject -= SpaceEnvironment.EventController_OnShowCelestialObject;
                Events.OnHideCelestialObject -= SpaceEnvironment.EventController_OnHideCelestialObject;
            }
            disposed = true;
        }
    }

    public void QuickLoad()
    {
        Events.GameServer.QuickLoad();
        Screens.ShowTacticalGameScreen();
    }

    public void Load(string saveName)
    {
        Events.GameServer.Load(saveName);
        Screens.ShowTacticalGameScreen();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void ZoomIn()
    {
        Screens.Settings.Zoom.In();
    }

    public void ZoomOut()
    {
        Screens.Settings.Zoom.Out();
    }

    ~GameManager()
    {
        Dispose(false);
    }
}
