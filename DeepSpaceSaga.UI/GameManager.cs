namespace DeepSpaceSaga.UI;

public class GameManager : IGameManager
{
    public OuterSpace OuterSpace { get; set; } = new OuterSpace();
    public SaveLoadManager SaveLoadSystem { get; set; } = new SaveLoadManager();
    private IEventManager _eventManager { get; set; }
    private IScreenManager _screenManager { get; set; }
    private IScreenInfo _screenInfo { get; set; }

    private bool disposed;

    public IEventManager Events
    {
        get => _eventManager;
        private set => _eventManager = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IScreenManager Screens
    {
        get => _screenManager;
        private set => _screenManager = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IScreenInfo ScreenInfo
    {
        get => _screenInfo;
        private set => _screenInfo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public GameManager(IEventManager eventManager, IScreenManager screenManager, IScreenInfo screenInfo)
    {
        _eventManager = eventManager;

        _screenManager = screenManager;

        _screenInfo = screenInfo;

        SubscribeToEvents();
    }

    public void Initialization()
    {
        Screens.GameInitialization();
    }

    private void SubscribeToEvents()
    {
        Events.OnSelectCelestialObject += OuterSpace.EventController_OnSelectCelestialObject;
        Events.OnUnselectCelestialObject += OuterSpace.EventController_OnUnselectCelestialObject;
        Events.OnShowCelestialObject += OuterSpace.EventController_OnShowCelestialObject;
        Events.OnHideCelestialObject += OuterSpace.EventController_OnHideCelestialObject;        
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
                Events.OnSelectCelestialObject -= OuterSpace.EventController_OnSelectCelestialObject;
                Events.OnUnselectCelestialObject -= OuterSpace.EventController_OnUnselectCelestialObject;
                Events.OnShowCelestialObject -= OuterSpace.EventController_OnShowCelestialObject;
                Events.OnHideCelestialObject -= OuterSpace.EventController_OnHideCelestialObject;
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

    ~GameManager()
    {
        Dispose(false);
    }
}
