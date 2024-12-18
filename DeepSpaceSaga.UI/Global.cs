namespace DeepSpaceSaga.UI;
using log4net;

public class Global
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Global));
    
    public static GameManager GameManager { get; private set; }
    public static ScreenParameters ScreenData { get; private set; }
    public static GlobalResources Resources { get; private set; }

    // Предотвращаем создание экземпляров
    private Global() { }

    public static void GameInitialization()
    {
        try 
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.Info("Начало инициализации игры");

            InitializeScreen();
            InitializeResources();
            InitializeGameManager();

            Logger.Info("Инициализация игры успешно завершена");
        }
        catch (Exception ex)
        {
            Logger.Error("Ошибка при инициализации игры", ex);
            throw new GameInitializationException("Критическая ошибка при инициализации игры", ex);
        }
    }

    private static void InitializeScreen()
    {
        Logger.Debug("Начало инициализации экрана");
        var monitorId = 0;
        var screens = Screen.AllScreens;
        
        if (screens == null || screens.Length == 0)
        {
            throw new GameInitializationException("Не найдены доступные мониторы");
        }

        if (monitorId >= screens.Length)
        {
            throw new GameInitializationException($"Недопустимый ID монитора: {monitorId}");
        }

        Rectangle resolution = screens[monitorId].Bounds;
        ScreenData = new ScreenParameters(resolution.Width, resolution.Height)
        {
            MonitorId = monitorId
        };
        Logger.Debug($"Экран инициализирован: {resolution.Width}x{resolution.Height}");
    }

    private static void InitializeResources()
    {
        if (ScreenData == null)
        {
            throw new InvalidOperationException("ScreenData должен быть инициализирован перед Resources");
        }
        
        Resources = new GlobalResources(ScreenData);
    }

    private static void InitializeGameManager()
    {
        GameManager = new GameManager(new EventManager());
    }

    public static void Cleanup()
    {
        Logger.Info("Начало очистки ресурсов");
        Resources?.Dispose();
        GameManager?.Dispose();
        Logger.Info("Очистка ресурсов завершена");
    }
}

public class GameInitializationException : Exception
{
    public GameInitializationException(string message) : base(message) { }
    public GameInitializationException(string message, Exception inner) : base(message, inner) { }
}
