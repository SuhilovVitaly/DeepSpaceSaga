using DeepSpaceSaga.UI.Render.Model;

namespace DeepSpaceSaga.UI;

public class Global
{
    public static Worker Worker { get; set; } = new Worker();

    public static ScreenParameters ScreenData { get; set; }

    public static GlobalResources Resources { get; set; }

    public static void GameInitialization()
    {
        log4net.Config.XmlConfigurator.Configure();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        ScreenData = new ScreenParameters(resolution.Width, resolution.Height);

        Resources = new GlobalResources(ScreenData);

        Worker.Initialize();
    }
}
