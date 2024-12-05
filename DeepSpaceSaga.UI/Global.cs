namespace DeepSpaceSaga.UI;

public class Global
{
    public static GameManager GameManager { get; set; }
    public static ScreenParameters ScreenData { get; set; }

    public static GlobalResources Resources { get; set; }

    public static void GameInitialization()
    {
        log4net.Config.XmlConfigurator.Configure();

        var monitorId = 1;
        Rectangle resolution = Screen.AllScreens[monitorId].Bounds;

        ScreenData = new ScreenParameters(resolution.Width, resolution.Height)
        {
            MonitorId = monitorId
        };

        Resources = new GlobalResources(ScreenData);

        GameManager = new GameManager(new EventManager());
    }
}
