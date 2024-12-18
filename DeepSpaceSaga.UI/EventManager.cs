using DeepSpaceSaga.Server;
using DeepSpaceSaga.Common.Tools.Telemetry;

namespace DeepSpaceSaga.Controller;

public class EventManager
{
    public event Action<SpaceMapPoint>? OnTacticalMapMouseMove;
    public event Action<GameSession>? OnRefreshData;
    public event Action<GameSession>? OnInitializeData;
    public event Action<ICelestialObject>? OnSelectCelestialObject;
    public event Action<ICelestialObject>? OnUnselectCelestialObject;
    public event Action<ICelestialObject>? OnShowCelestialObject;
    public event Action<ICelestialObject>? OnHideCelestialObject;

    private GameSession session = null!;

    private GameSession Session
    {
        get => Interlocked.CompareExchange(ref session, null, null);
        set => Interlocked.Exchange(ref session, value);
    }

    private SpaceMapEventHandler MapEventHandler { get; init; }

    private readonly Worker Worker;

    public EventManager()
    {
        Worker = new Worker(new LocalGameServer(new ServerMetrics(), new LocalGameServerOptions()));
        InitializeAsync().GetAwaiter().GetResult();

        Worker.OnGetDataFromServer += Worker_RefreshData;
        Worker.OnGameInitialize += Worker_OnGameInitialize;

        MapEventHandler = new SpaceMapEventHandler();

        MapEventHandler.OnShowCelestialObject += MapEventHandler_OnShowCelestialObject;
        MapEventHandler.OnHideCelestialObject += MapEventHandler_OnHideCelestialObject;
        MapEventHandler.OnSelectCelestialObject += MapEventHandler_OnSelectCelestialObject;
    }

    private async Task InitializeAsync()
    {
        await Worker.Initialize();
    }

    private void MapEventHandler_OnHideCelestialObject(ICelestialObject celestialObject)
    {
        OnHideCelestialObject?.Invoke(celestialObject);
    }

    private void Worker_OnGameInitialize(GameSession gameSession)
    {
        OnInitializeData?.Invoke(gameSession);
    }

    private void Worker_RefreshData(GameSession gameSession)
    {
        OnRefreshData?.Invoke(gameSession);
        Session = gameSession;
    }

    public void TacticalMapMouseMove(SpaceMapPoint coordinates)
    {
        MapEventHandler.MouseMove(coordinates, Worker.GetGameSession());

        OnTacticalMapMouseMove?.Invoke(coordinates);
    }

    public void TacticalMapMouseClick(SpaceMapPoint coordinates)
    {
        MapEventHandler.MouseClick(coordinates, Worker.GetGameSession());
    }

    private void MapEventHandler_OnSelectCelestialObject(ICelestialObject celestialObject)
    {
        OnSelectCelestialObject?.Invoke(celestialObject);
    }

    private void MapEventHandler_OnShowCelestialObject(ICelestialObject celestialObject)
    {
        OnShowCelestialObject?.Invoke(celestialObject);
    }

    public GameSession GetSession()
    {
        return Worker.GetGameSession();
    }

    public void Resume()
    {
        Worker.Resume();
    }

    public void Pause()
    {
        Worker.Pause();
    }

    public void SetGameSpeed(int speed)
    {
        Worker.SetGameSpeed(speed);
    }

    public async Task ExecuteCommandAsync(Command command)
    {
        await Worker.SendCommandAsync(command);
    }

    internal void TacticalMapLeftMouseClick(SpaceMapPoint mouseLocation)
    {
        OnUnselectCelestialObject?.Invoke(null);
    }
}
