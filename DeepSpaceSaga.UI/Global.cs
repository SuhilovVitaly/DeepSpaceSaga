namespace DeepSpaceSaga.UI;

public class Global
{
    public static GameManager GameManager { get; set; }
    public static ScreenParameters ScreenData { get; set; }

    public static GlobalResources Resources { get; set; }

    public static void GameInitialization()
    {
        log4net.Config.XmlConfigurator.Configure();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        ScreenData = new ScreenParameters(resolution.Width, resolution.Height);

        Resources = new GlobalResources(ScreenData);

        GameManager = new GameManager(new EventManager());
    }
}
