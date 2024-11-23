using DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;
using DeepSpaceSaga.UI.Render.Model;

namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    public event Action<MouseEventArgs>? OnMouseMove;

    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;

    private GameSession lastGameSessionData;

    public StellarTacticalMap()
    {
        InitializeComponent();

        Global.Worker.OnGetDataFromServer += Worker_RefreshData;
        Global.Worker.OnGameInitialize += Worker_OnGameInitialize;
        lastGameSessionData = Global.Worker.GetGameSession();
    }

    private void Worker_OnGameInitialize(GameSession data)
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

    private void Worker_RefreshData(GameSession data)
    {
        if (isDrawInProcess) return;

        isDrawInProcess = true;

        lastGameSessionData = data;

        CrossThreadExtensions.PerformSafely(this, RefreshControls, data);

        isDrawInProcess = false;
    }

    private void RefreshControls(GameSession data)
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
            var spacecraftLocation = data.SpaceMap.GetCelestialObjects().Where(x => x.OwnerId == 1).FirstOrDefault()?.GetLocation();

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

    private void imageTacticalMap_MouseMove(object sender, MouseEventArgs e)
    {
        OnMouseMove?.Invoke(e);
    }
}
