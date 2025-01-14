﻿namespace DeepSpaceSaga.UI.Manager.Screens;

public class ScreenManager: IScreenManager
{
    Dictionary<ScreenType, Form> _screens = [];
    private BackgroundScreen _screenBackground;
    private TacticGameScreen _tacticGameScreen;

    public ScreenManager()
    {
        _screenBackground = Program.ServiceProvider.GetService<BackgroundScreen>();        

        _screenBackground.FirstShown += (sender, e) =>
        {
            ShowMenuScreen();
        };

        _screens.Add(ScreenType.Background, _screenBackground);
    }

    public void GameInitialization()
    {
        _tacticGameScreen = Program.ServiceProvider.GetService<TacticGameScreen>();
        _tacticGameScreen.Initialization();
    }

    public void ShowMenuScreen()
    {
        if (_screens.ContainsKey(ScreenType.MainMenu) == false)
        {
            _screens.Add(ScreenType.MainMenu, Program.ServiceProvider.GetService<MainMenuScreen>());
        }

        _screenBackground.ShowChildForm(_screens[ScreenType.MainMenu]);
    }

    public void ShowGameMenuScreen()
    {
        if (_screens.ContainsKey(ScreenType.GameMenu) == false)
        {
            _screens.Add(ScreenType.GameMenu, Program.ServiceProvider.GetService<GameMenuScreen>());
        }

        _screenBackground.ShowChildForm(_screens[ScreenType.GameMenu], true);
    }

    public void ShowTacticalGameScreen()
    {
        if (_screens.ContainsKey(ScreenType.TacticalGame) == false)
        {
            _screens.Add(ScreenType.TacticalGame, Program.ServiceProvider.GetService<TacticGameScreen>());
        }

        _screenBackground.ShowChildForm(_screens[ScreenType.TacticalGame]);
    }

    public void ShowSaveGameScreen()
    {
        if (_screens.ContainsKey(ScreenType.SaveGame) == false)
        {
            _screens.Add(ScreenType.SaveGame, Program.ServiceProvider.GetService<SaveGameScreen>());
        }

        _screenBackground.ShowChildForm(_screens[ScreenType.SaveGame], true);
    }

    public void ShowLoadGameScreen()
    {
        if (_screens.ContainsKey(ScreenType.LoadGame) == false)
        {
            _screens.Add(ScreenType.LoadGame, Program.ServiceProvider.GetService<LoadGameScreen>());
        }

        _screenBackground.ShowChildForm(_screens[ScreenType.LoadGame], true);
    }
}
