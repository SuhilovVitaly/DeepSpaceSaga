namespace DeepSpaceSaga.UI;

public interface IGameManager : IDisposable
{
    OuterSpace OuterSpace { get; set; }
    SaveLoadManager SaveLoadSystem { get; set; }
    IEventManager EventController { get; }

    void SetBackgroundScreenReference(BackgroundScreen screenBackground);
    void SetMenuScreen(MainMenuScreen screenMenu);
    void ShowMenuScreen();
    void SetGameMenuScreen(GameMenuScreen screenGameMenu);
    void ShowGameMenuScreen();
    void SetTacticalGameScreen(TacticGameScreen screenTacticalGame);
    void ShowTacticalGameScreen();
    void SetSaveGameScreen(SaveGameScreen saveGameScreen);
    void ShowSaveGameScreen();
    void SetLoadGameScreen(LoadGameScreen loadGameScreen);
    void ShowLoadGameScreen();
    ISpacecraft GetPlayerSpacecraft();
    ICelestialObject GetCelestialObject(int id);
    CelestialMap GetCelestialMap();
    GameSession GetSession();
    Task ExecuteCommandAsync(ICommand command);
    void QuickLoad();
    void Load(string saveName);
}
