using DeepSpaceSaga.Common.Universe.Commands;

namespace DeepSpaceSaga.Controller;

public class EventManager
{
    public event Action<PointF>? OnTacticalMapMouseMove;
    public event Action<GameSession>? OnRefreshData;
    public event Action<GameSession>? OnInitializeData;

    private GameSession session;

    private GameSession Session
    {
        get => Interlocked.CompareExchange(ref session, null, null);
        set => Interlocked.Exchange(ref session, value);
    }

    private SpaceMapEventHandler MapEventHandler { get; init; }

    private readonly Worker Worker;

    public EventManager()
    {
        Worker = new Worker();
        Worker.Initialize();

        Worker.OnGetDataFromServer += Worker_RefreshData;
        Worker.OnGameInitialize += Worker_OnGameInitialize;

        MapEventHandler = new SpaceMapEventHandler();

        MapEventHandler.OnShowCelestialObject += MapEventHandler_OnShowCelestialObject;
        MapEventHandler.OnSelectCelestialObject += MapEventHandler_OnSelectCelestialObject;
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

    public void TacticalMapMouseMove(PointF coordinates)
    {
        MapEventHandler.MouseMove(coordinates, Worker.GetGameSession());

        OnTacticalMapMouseMove?.Invoke(coordinates);
    }

    public void TacticalMapMouseClick(PointF coordinates)
    {
        MapEventHandler.MouseClick(coordinates, Worker.GetGameSession());
    }

    private void MapEventHandler_OnSelectCelestialObject(ICelestialObject obj)
    {

    }

    private void MapEventHandler_OnShowCelestialObject(ICelestialObject obj)
    {

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

    public async Task ExecuteCommandAsync(Command command)
    {
        await Worker.SendCommandAsync(command);
    }
}
