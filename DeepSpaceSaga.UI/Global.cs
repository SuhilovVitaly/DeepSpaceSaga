namespace DeepSpaceSaga.UI;

public class Global
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Global));
    
    public static IGameManager GameManager { get; private set; }
    public static ScreenParameters ScreenData { get; private set; }
    public static GlobalResources Resources { get; private set; }

    private Global() { }

    public static void GameInitialization()
    {
        try 
        {
            Logger.Info("Start game initialization");

            InitializeScreen();
            InitializeResources();
            InitializeGameManager();

            Logger.Info("Finish game initialization");
        }
        catch (Exception ex)
        {
            Logger.Error("Error on game initialization", ex);
            throw new GameInitializationException("Critical error on game initialization", ex);
        }
    }

    private static void InitializeScreen()
    {
        Logger.Debug("Start screen initialization");
        var monitorId = 0;
        var screens = Screen.AllScreens;
        
        if (screens == null || screens.Length == 0)
        {
            throw new GameInitializationException("Monitors not found");
        }

        if (monitorId >= screens.Length)
        {
            throw new GameInitializationException($"Wrong ID of monitor: {monitorId}");
        }

        Rectangle resolution = screens[monitorId].Bounds;
        ScreenData = new ScreenParameters(resolution.Width, resolution.Height)
        {
            MonitorId = monitorId
        };
        Logger.Debug($"Finish screen initialization: {resolution.Width}x{resolution.Height}");
    }

    private static void InitializeResources()
    {
        Resources = new GlobalResources(ScreenData);
    }

    private static void InitializeGameManager()
    {
        GameManager = Program.ServiceProvider.GetService<IGameManager>();
    }

    public static void Cleanup()
    {
        Resources?.Dispose();
        GameManager?.Dispose();
    }
}


