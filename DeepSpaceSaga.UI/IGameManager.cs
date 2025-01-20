namespace DeepSpaceSaga.UI;

public interface IGameManager : IDisposable
{
    IOuterSpace SpaceEnvironment { get; set; }
    ISaveLoadManager SaveLoadSystem { get; set; }
    IEventManager Events { get; }
    IScreenManager Screens { get; }
    ISpacecraft GetPlayerSpacecraft();
    ICelestialObject GetCelestialObject(int id);
    CelestialMap GetCelestialMap();
    GameSessionDTO GetSession();
    Task ExecuteCommandAsync(ICommand command);
    void QuickLoad();
    void Load(string saveName);
    void ZoomIn();
    void ZoomOut();
}
