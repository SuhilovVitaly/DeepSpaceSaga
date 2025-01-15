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

        log4net.Config.XmlConfigurator.Configure();

        Logger.Info("Start 'Deep Space Saga' game desktop client.");

        var host = CreateHostBuilder().Build();

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
                services.AddClientServices();
                services.AddClientScreens();
                services.AddServerServices();
            });
    }
}