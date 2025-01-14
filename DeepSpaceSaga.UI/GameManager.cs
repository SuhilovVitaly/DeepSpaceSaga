﻿using DeepSpaceSaga.UI.Manager.Screens;

namespace DeepSpaceSaga.UI;

public class GameManager : IGameManager
{
    public OuterSpace OuterSpace { get; set; } = new OuterSpace();
    public SaveLoadManager SaveLoadSystem { get; set; } = new SaveLoadManager();
    private IEventManager _eventManager { get; set; }
    private bool disposed;
    private BackgroundScreen _screenBackground;
    private MainMenuScreen _screenMenu;
    private GameMenuScreen _screenGameMenu;
    private SaveGameScreen _saveGameScreen;
    private LoadGameScreen _loadGameScreen;
    private TacticGameScreen _screenTacticalGame;


    public IEventManager EventController
    {
        get => _eventManager;
        private set => _eventManager = value ?? throw new ArgumentNullException(nameof(value));
    }

    public GameManager(IEventManager eventManager, IScreenManager screenManager)
    {
        _eventManager = eventManager;

        SubscribeToEvents();
    }

    public void SetBackgroundScreenReference(BackgroundScreen screenBackground)
    {
        _screenBackground = screenBackground;
        _screenBackground.FirstShown += (sender, e) =>
        {
            StartGameProcess();
        };
    }

    public void SetMenuScreen(MainMenuScreen screenMenu)
    {
        _screenMenu = screenMenu;
    }

    public void ShowMenuScreen()
    {
        _screenBackground.ShowChildForm(_screenMenu);
    }

    public void SetGameMenuScreen(GameMenuScreen screenGameMenu)
    {
        _screenGameMenu = screenGameMenu;
    }

    public void ShowGameMenuScreen()
    {
        _screenBackground.ShowChildForm(_screenGameMenu, true);
    }

    public void SetTacticalGameScreen(TacticGameScreen screenTacticalGame)
    {
        _screenTacticalGame = screenTacticalGame;
    }

    public void ShowTacticalGameScreen()
    {
        _screenBackground.ShowChildForm(_screenTacticalGame);
    }

    public void SetSaveGameScreen(SaveGameScreen saveGameScreen)
    {
        _saveGameScreen = saveGameScreen;
    }

    public void ShowSaveGameScreen()
    {
        _screenBackground.ShowChildForm(_saveGameScreen, true);
    }

    public void SetLoadGameScreen(LoadGameScreen loadGameScreen)
    {
        _loadGameScreen = loadGameScreen;
    }

    public void ShowLoadGameScreen()
    {
        _screenBackground.ShowChildForm(_loadGameScreen, true);
    }

    private void StartGameProcess()
    {
        _screenBackground.ShowChildForm(_screenMenu);
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
        _screenBackground.ShowChildForm(_screenTacticalGame);
    }

    public void Load(string saveName)
    {
        EventController.GameServer.Load(saveName);
        _screenBackground.ShowChildForm(_screenTacticalGame);
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
