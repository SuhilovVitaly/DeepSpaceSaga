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

    private static readonly ILog Logger = LogManager.GetLogger(typeof(EventManager));

    private SpaceMapEventHandler MapEventHandler { get; set; }
    private Form1 _screenTacticalMap;
    private Worker Worker;

    public EventManager(GenerationTool randomizer)
    {
        Initialization(randomizer).GetAwaiter().GetResult();
    }

    private async Task Initialization(GenerationTool randomizer)
    {
        var metrics = new ServerMetrics();
        var settings = new LocalGameServerOptions();
        IGameEngine engine = new GameEngine(settings, metrics);

        Worker = new Worker(new LocalGameServer(metrics, settings, new GameActionEvents(new List<GameActionEvent>()), engine, randomizer));
        await InitializeAsync();

        Worker.OnGetDataFromServer += Worker_RefreshData;
        Worker.OnGameInitialize += Worker_OnGameInitialize;

        MapEventHandler = new SpaceMapEventHandler();

        MapEventHandler.OnShowCelestialObject += MapEventHandler_OnShowCelestialObject;
        MapEventHandler.OnHideCelestialObject += MapEventHandler_OnHideCelestialObject;
        MapEventHandler.OnSelectCelestialObject += MapEventHandler_OnSelectCelestialObject;

        Logger.Info("The object has been successfully initialized.");
    }

    public void SetMainGameScreenReference(Form1 screenTacticalMap)
    {
        _screenTacticalMap = screenTacticalMap;
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

    public void ItemsTransferScreenShow(GameActionEvent gameEvent)
    {
        _screenTacticalMap.OpenCargoUI(gameEvent.Copy());
    }

    private void Worker_RefreshData(GameSession gameSession)
    {
        ArgumentNullException.ThrowIfNull(gameSession);

        try
        {
            // Notify subscribers about data refresh
            OnRefreshData?.Invoke(gameSession);

            if (gameSession.State.IsPaused)
                return;

            // Process game events if any exist
            if (gameSession.Events?.Any() == true && _screenTacticalMap != null)
            {
                GameEventsHandker.Execute(gameSession, _screenTacticalMap);
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"Failed to process game session: {ex.Message}");
            throw;
        }
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

    public async Task ExecuteCommandAsync(ICommand command)
    {
        await Worker.SendCommandAsync(command);
    }

    internal void TacticalMapLeftMouseClick(SpaceMapPoint mouseLocation)
    {
        OnUnselectCelestialObject?.Invoke(null);
    }
}
