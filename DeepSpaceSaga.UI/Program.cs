using DeepSpaceSaga.UI.Screens.LoadGame;
using DeepSpaceSaga.UI.Screens.SaveGame;

namespace DeepSpaceSaga.UI;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

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
}