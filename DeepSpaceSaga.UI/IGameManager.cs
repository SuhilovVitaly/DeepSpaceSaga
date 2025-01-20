namespace DeepSpaceSaga.UI;

public interface IGameManager : IDisposable
{
    OuterSpace OuterSpace { get; set; }
    SaveLoadManager SaveLoadSystem { get; set; }
    IEventManager Events { get; }
    IScreenManager Screens { get; }
    IScreenInfo ScreenData { get; }
    ISpacecraft GetPlayerSpacecraft();
    ICelestialObject GetCelestialObject(int id);
    CelestialMap GetCelestialMap();
    GameSessionDTO GetSession();
    Task ExecuteCommandAsync(ICommand command);
    void QuickLoad();
    void Load(string saveName);
    void Initialization();
}
