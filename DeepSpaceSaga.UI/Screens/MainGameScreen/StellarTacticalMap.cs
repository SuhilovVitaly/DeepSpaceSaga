namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    public event Action<MouseEventArgs>? OnMouseMove;

    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;

    private GameManager lastGameSessionData;

    public StellarTacticalMap()
    {
        InitializeComponent();

        imageTacticalMap.MouseClick += MapClick;
        imageTacticalMap.MouseMove += MapMouseMove;

        if (Global.Worker == null) return;

        Global.Worker.OnGetDataFromServer += Worker_RefreshData;
        Global.Worker.OnGameInitialize += Worker_OnGameInitialize;
        lastGameSessionData = Global.Worker.GetGameManager();
    }

    private void Worker_OnGameInitialize(GameManager data)
    {
        lastGameSessionData = data;
        RefreshControls(data);
    }

    public void Initialization()
    {
        Logger.Info($"Initialization finished. Zoom is {Global.ScreenData.Zoom}");

        if (lastGameSessionData == null) return;

        RefreshControls(lastGameSessionData);
    }

    private void Worker_RefreshData(GameManager data)
    {
        if (isDrawInProcess) return;

        isDrawInProcess = true;

        lastGameSessionData = data;

        CrossThreadExtensions.PerformSafely(this, RefreshControls, data);

        isDrawInProcess = false;
    }

    private void RefreshControls(GameManager data)
    {
        var image = new Bitmap(Width, Height);

        var graphics = Graphics.FromImage(image);

        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        Global.ScreenData =
                new ScreenParameters(Width, Height, (int)Global.ScreenData.CenterScreenOnMap.X, (int)Global.ScreenData.CenterScreenOnMap.Y)
                {
                    GraphicSurface = graphics
                };

        if(Global.ScreenData.IsPlayerSpacecraftCenterScreen)
        {
            var spacecraftLocation = data.GetCelestialMap().GetCelestialObjects().Where(x => x.OwnerId == 1).FirstOrDefault()?.GetLocation();

            if(spacecraftLocation != null)
            {
                Global.ScreenData =
                new ScreenParameters(Width, Height, (int)spacecraftLocation.Value.X, (int)spacecraftLocation.Value.Y)
                {
                    GraphicSurface = graphics
                };
            }            
        }

        Global.Resources.DrawTool.DrawTacticalMapScreen(graphics, data, Global.ScreenData);

        graphics.DrawString($"{DateTime.Now.Second}.{DateTime.Now.Millisecond}", new Font("Tahoma", 8), Brushes.White, new RectangleF(70, 90, 90, 50));

        imageTacticalMap.Image?.Dispose();
        imageTacticalMap.Image = image;

        graphics.Dispose();
    }

    private void MapMouseMove(object sender, MouseEventArgs e)
    {
        // Event to container
        OnMouseMove?.Invoke(e);

        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(e.Location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        lastGameSessionData.MapEventHandler.MouseMove(mouseLocation);
    }
    private void MapClick(object sender, MouseEventArgs e)
    {
        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(e.Location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        lastGameSessionData.MapEventHandler.MouseClick(mouseLocation);
    }
}
