namespace DeepSpaceSaga.UI.Manager.Screens;

public interface IScreenManager
{
    IScreenInfo Settings { get; }
    void ShowMenuScreen();
    void ShowGameMenuScreen();
    void ShowTacticalGameScreen();
    void ShowSaveGameScreen();
    void ShowLoadGameScreen();
    void GameInitialization();
}
