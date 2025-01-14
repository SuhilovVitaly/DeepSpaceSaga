namespace DeepSpaceSaga.UI.Manager.Screens;

public class ScreenManager: IScreenManager
{
    Dictionary<ScreenType, Form> _screens = [];

    public ScreenManager()
    {
        _screens.Add(ScreenType.Background, Program.ServiceProvider.GetService<BackgroundScreen>());
        _screens.Add(ScreenType.MainMenu, Program.ServiceProvider.GetService<MainMenuScreen>());
        _screens.Add(ScreenType.GameMenu, Program.ServiceProvider.GetService<GameMenuScreen>());
        _screens.Add(ScreenType.SaveGame, Program.ServiceProvider.GetService<SaveGameScreen>());
        _screens.Add(ScreenType.LoadGame, Program.ServiceProvider.GetService<LoadGameScreen>());
        _screens.Add(ScreenType.TacticalGame, Program.ServiceProvider.GetService<TacticGameScreen>());
    }
}
