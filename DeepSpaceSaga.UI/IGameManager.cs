﻿namespace DeepSpaceSaga.UI;

public interface IGameManager : IDisposable
{
    OuterSpace OuterSpace { get; set; }
    SaveLoadManager SaveLoadSystem { get; set; }
    IEventManager EventController { get; }
    IScreenManager Screens { get; }
    ISpacecraft GetPlayerSpacecraft();
    ICelestialObject GetCelestialObject(int id);
    CelestialMap GetCelestialMap();
    GameSession GetSession();
    Task ExecuteCommandAsync(ICommand command);
    void QuickLoad();
    void Load(string saveName);
    void Initialization();
}
