﻿namespace DeepSpaceSaga.UI;

public class GameManager : IGameManager
{
    public OuterSpace OuterSpace { get; set; } = new OuterSpace();
    public SaveLoadManager SaveLoadSystem { get; set; } = new SaveLoadManager();
    private IEventManager _eventManager { get; set; }
    private IScreenManager _screenManager { get; set; }
    private bool disposed;

    public IEventManager EventController
    {
        get => _eventManager;
        private set => _eventManager = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IScreenManager Screens
    {
        get => _screenManager;
        private set => _screenManager = value ?? throw new ArgumentNullException(nameof(value));
    }

    public GameManager(IEventManager eventManager, IScreenManager screenManager)
    {
        _eventManager = eventManager;

        _screenManager = screenManager;

        SubscribeToEvents();
    }

    public void Initialization()
    {
        Screens.GameInitialization();
    }

    private void SubscribeToEvents()
    {
        EventController.OnSelectCelestialObject += OuterSpace.EventController_OnSelectCelestialObject;
        EventController.OnUnselectCelestialObject += OuterSpace.EventController_OnUnselectCelestialObject;
        EventController.OnShowCelestialObject += OuterSpace.EventController_OnShowCelestialObject;
        EventController.OnHideCelestialObject += OuterSpace.EventController_OnHideCelestialObject;        
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

    public GameSession GetSession()
    {
        return EventController.GetSession();
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await EventController.ExecuteCommandAsync(command);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                EventController.OnSelectCelestialObject -= OuterSpace.EventController_OnSelectCelestialObject;
                EventController.OnUnselectCelestialObject -= OuterSpace.EventController_OnUnselectCelestialObject;
                EventController.OnShowCelestialObject -= OuterSpace.EventController_OnShowCelestialObject;
                EventController.OnHideCelestialObject -= OuterSpace.EventController_OnHideCelestialObject;
            }
            disposed = true;
        }
    }

    public void QuickLoad()
    {
        EventController.GameServer.QuickLoad();
        Screens.ShowTacticalGameScreen();
    }

    public void Load(string saveName)
    {
        EventController.GameServer.Load(saveName);
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
