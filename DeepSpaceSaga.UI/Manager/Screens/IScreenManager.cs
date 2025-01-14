namespace DeepSpaceSaga.UI.Manager.Screens;

public interface IScreenManager
{
    void ShowMenuScreen();
    void ShowGameMenuScreen();
    void ShowTacticalGameScreen();
    void ShowSaveGameScreen();
    void ShowLoadGameScreen();
    void GameInitialization();
}
