namespace DeepSpaceSaga.UI;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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

        ApplicationConfiguration.Initialize();

        Global.GameInitialization();

        var services = new ServiceCollection();

        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();

        var mainForm = ServiceProvider.GetRequiredService<Form1>();
        Application.Run(mainForm);

        Logger.Info("Finished 'Deep Space Saga' game desktop client.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        try
        {
            Logger.Debug("Configuring services...");

            // Регистрация форм
            services.AddScoped<Form1>();
            //services.AddScoped<GameSettingsForm>();

            // Регистрация игровой логики
            //services.AddTurnCalculation();

            Logger.Debug("Services configured successfully");
        }
        catch (Exception ex)
        {
            Logger.Error("Error configuring services", ex);
            throw;
        }
    }
}