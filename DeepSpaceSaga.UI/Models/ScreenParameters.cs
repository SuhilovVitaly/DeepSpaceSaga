namespace DeepSpaceSaga.UI.Render.Model;

public class ScreenParameters : IScreenInfo
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(ScreenParameters));
    public ScreenMetrics Metrics { get; set; } = new ScreenMetrics();
    public SpaceMapPoint Center { get; private set; }
    public float Width { get; private set; }
    public float Height { get; private set; }
    public int DrawInterval { get; set; }
    public SpaceMapPoint CenterScreenOnMap { get; set; }
    public SKCanvas GraphicSurface { get; set; }
    public Zoom Zoom { get; private set; }
    public int MonitorId { get; set; }

    public bool IsPlayerSpacecraftCenterScreen { get; set; } = true;

    public ScreenParameters()
    {
        Logger.Debug("Start screen initialization");

        var monitorId = 0;
        var screens = Screen.AllScreens;

        if (screens == null || screens.Length == 0)
        {
            throw new Exception("Monitors not found");
        }

        if (monitorId >= screens.Length)
        {
            throw new Exception($"Wrong ID of monitor: {monitorId}");
        }

        var resolution = screens[monitorId].Bounds;

        MonitorId = monitorId;

        Initialization(resolution.Width, resolution.Height);

        Logger.Debug($"Finish screen initialization: {resolution.Width}x{resolution.Height}");
    }

    public ScreenParameters(float width, float height, int centerScreenX = 10000, int centerScreenY = 10000, int zoomSize = 1000)
    {
        Initialization(width, height, centerScreenX, centerScreenY, zoomSize);        
    }

    public ScreenParameters(ScreenParameters preset, int zoomSize)
    {
        Center = preset.Center;
        CenterScreenOnMap = preset.CenterScreenOnMap;
        Width = preset.Width;
        Height = preset.Height;
        Zoom = new Zoom(zoomSize);
    }

    private void Initialization(float width, float height, int centerScreenX = 10000, int centerScreenY = 10000, int zoomSize = 1000)
    {
        Center = new SpaceMapPoint(width / 2, height / 2);

        // Start player ship coordinates in each battle (10000, 10000)
        CenterScreenOnMap = new SpaceMapPoint(centerScreenX, centerScreenY);

        Width = width;
        Height = height;

        Zoom = new Zoom(zoomSize);
    }
}

