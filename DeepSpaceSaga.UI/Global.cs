namespace DeepSpaceSaga.UI;

public class Global
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Global));    
    public static IGameManager GameManager { get; private set; }
    public static GlobalResources Resources { get; private set; }

    private Global() { }

    public static void GameInitialization()
    {
        try 
        {
            Logger.Info("Start game initialization");

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

    private static void InitializeResources()
    {
        Resources = new GlobalResources();
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


