namespace DeepSpaceSaga.UI;

internal static class Program
{
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

        Application.Run(new Form1());

        Logger.Info("Finished 'Deep Space Saga' game desktop client.");
    }
}