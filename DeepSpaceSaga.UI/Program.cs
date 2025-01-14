using DeepSpaceSaga.UI.Manager.Screens;

namespace DeepSpaceSaga.UI;

internal static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        Environment.SetEnvironmentVariable("SKIA_BACKEND", "software");

        log4net.Config.XmlConfigurator.Configure();

        Logger.Info("Start 'Deep Space Saga' game desktop client.");

        var host = CreateHostBuilder()
            .ConfigureServices(CreateScreensBuilder)
            .Build();
        ServiceProvider = host.Services;

        ApplicationConfiguration.Initialize();

        Global.GameInitialization();

        Application.Run(ServiceProvider.GetService<BackgroundScreen>());

        Logger.Info("Finished 'Deep Space Saga' game desktop client.");
    }

    
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                // Core services registration
                RegisterCoreServices(services);
            });
    }

    static void CreateScreensBuilder(IServiceCollection services)
    {
        // Screen services registration
        services.AddScoped<BackgroundScreen>();
        services.AddTransient<MainMenuScreen>();
        services.AddTransient<GameMenuScreen>();
        services.AddTransient<SaveGameScreen>();
        services.AddTransient<LoadGameScreen>();
        services.AddScoped<TacticGameScreen>();
    }

    static void RegisterCoreServices(IServiceCollection services)
    {
        services.AddScoped<ILocalGameServerOptions, LocalGameServerOptions>();
        services.AddScoped<IServerMetrics, ServerMetrics>();
        services.AddTransient<ISaveLoadService, SaveLoadService>();
        services.AddScoped<IGenerationTool, GenerationTool>();
        services.AddScoped<IEventManager, EventManager>();
        services.AddScoped<IScreenManager, ScreenManager>();
        services.AddScoped<IGameManager, GameManager>();
        services.AddScoped<IGameEngine, GameEngine>();
        services.AddTransient<IGameServerService, GameServerService>();
    }
}