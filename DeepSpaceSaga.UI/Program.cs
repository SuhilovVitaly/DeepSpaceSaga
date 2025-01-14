namespace DeepSpaceSaga.UI;

internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        Environment.SetEnvironmentVariable("SKIA_BACKEND", "software");

        log4net.Config.XmlConfigurator.Configure();

        Logger.Info("Start 'Deep Space Saga' game desktop client.");


        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        ApplicationConfiguration.Initialize();

        Global.GameInitialization();

        var backgroundScreen = new BackgroundScreen();

        Global.GameManager.SetBackgroundScreenReference(backgroundScreen);
        Global.GameManager.SetMenuScreen(new MainMenuScreen());
        Global.GameManager.SetGameMenuScreen(new GameMenuScreen());
        Global.GameManager.SetSaveGameScreen(new SaveGameScreen());
        Global.GameManager.SetLoadGameScreen(new LoadGameScreen());
        Global.GameManager.SetTacticalGameScreen(new TacticGameScreen());

        Application.Run(backgroundScreen);

        Logger.Info("Finished 'Deep Space Saga' game desktop client.");
    }

    
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddScoped<ILocalGameServerOptions, LocalGameServerOptions>();
                services.AddScoped<IServerMetrics, ServerMetrics>();
                services.AddTransient<ISaveLoadService, SaveLoadService>();
                services.AddScoped<IGenerationTool, GenerationTool>();
                services.AddScoped<IGameEngine, GameEngine>();
                services.AddTransient<IGameServerService, GameServerService>();
            });
    }
}