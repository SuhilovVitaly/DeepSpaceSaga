using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;

    private GameSessionData lastGameSessionData;

    public StellarTacticalMap()
    {
        InitializeComponent();

        Global.Worker.OnGetDataFromServer += Worker_OnTurnRefresh;
        Global.Worker.OnGameInitialize += Worker_OnGameInitialize;
    }

    private void Worker_OnGameInitialize(GameSessionData data)
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

    private void Worker_OnTurnRefresh(GameSessionData data)
    {
        if(isDrawInProcess) return;

        isDrawInProcess = true;

        lastGameSessionData = data;

        CrossThreadExtensions.PerformSafely(this, RefreshControls, data);        

        isDrawInProcess = false;
    }

    private void RefreshControls(GameSessionData data)
    {
        var image = new Bitmap(Width, Height);

        var graphics = Graphics.FromImage(image);

        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        Global.Resources.DrawTool.DrawTacticalMapScreen(graphics, data, Global.ScreenData);

        graphics.DrawString($"{DateTime.Now.Second}.{DateTime.Now.Millisecond}", new Font("Tahoma", 8), Brushes.White, new RectangleF(70, 90, 90, 50));

        imageTacticalMap.Image?.Dispose();
        imageTacticalMap.Image = image;

        graphics.Dispose();
    }
}
