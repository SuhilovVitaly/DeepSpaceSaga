using System.Windows.Forms;

namespace DeepSpaceSaga.UI.Manager.Screens;

public class ScreenManager: IScreenManager
{
    Dictionary<ScreenType, Form> _screens = [];
    private BackgroundScreen _screenBackground;
    private TacticGameScreen _tacticGameScreen;

    public ScreenManager()
    {
        _screenBackground = Program.ServiceProvider.GetService<BackgroundScreen>();
        _tacticGameScreen = Program.ServiceProvider.GetService<TacticGameScreen>();

        _screenBackground.FirstShown += (sender, e) =>
        {
            ShowMenuScreen();
        };

        _screens.Add(ScreenType.Background, _screenBackground);
        _screens.Add(ScreenType.MainMenu, Program.ServiceProvider.GetService<MainMenuScreen>());
        _screens.Add(ScreenType.GameMenu, Program.ServiceProvider.GetService<GameMenuScreen>());
        _screens.Add(ScreenType.SaveGame, Program.ServiceProvider.GetService<SaveGameScreen>());
        _screens.Add(ScreenType.LoadGame, Program.ServiceProvider.GetService<LoadGameScreen>());
        _screens.Add(ScreenType.TacticalGame, Program.ServiceProvider.GetService<TacticGameScreen>());
    }

    public void GameInitialization()
    {
        _tacticGameScreen.Initialization();
    }

    public void ShowMenuScreen()
    {
        _screenBackground.ShowChildForm(_screens[ScreenType.MainMenu]);
    }

    public void ShowGameMenuScreen()
    {
        _screenBackground.ShowChildForm(_screens[ScreenType.GameMenu], true);
    }

    public void ShowTacticalGameScreen()
    {
        _screenBackground.ShowChildForm(_screens[ScreenType.TacticalGame]);
    }

    public void ShowSaveGameScreen()
    {
        _screenBackground.ShowChildForm(_screens[ScreenType.SaveGame], true);
    }

    public void ShowLoadGameScreen()
    {
        _screenBackground.ShowChildForm(_screens[ScreenType.LoadGame], true);
    }
}
