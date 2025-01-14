namespace DeepSpaceSaga.UI;

public interface IEventManager
{
    event Action<SpaceMapPoint>? OnTacticalMapMouseMove;
    event Action<GameSession>? OnRefreshData;
    event Action<GameSession>? OnInitializeData;
    event Action<ICelestialObject>? OnSelectCelestialObject;
    event Action<ICelestialObject>? OnUnselectCelestialObject;
    event Action<ICelestialObject>? OnShowCelestialObject;
    event Action<ICelestialObject>? OnHideCelestialObject;
    IGameServer GameServer { get; set; }

    void SetMainGameScreenReference(TacticGameScreen screenTacticalMap);
    void ItemsTransferScreenShow(GameActionEvent gameEvent);
    void TacticalMapMouseMove(SpaceMapPoint coordinates);
    void TacticalMapMouseClick(SpaceMapPoint coordinates);
    GameSession GetSession();
    void Resume();
    void Pause();
    void SetGameSpeed(int speed);
    void Save();
    void Load();
    Task ExecuteCommandAsync(ICommand command);
    void TacticalMapLeftMouseClick(SpaceMapPoint mouseLocation);
}
