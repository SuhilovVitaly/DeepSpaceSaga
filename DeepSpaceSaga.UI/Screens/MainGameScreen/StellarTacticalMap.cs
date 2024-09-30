namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;

    public StellarTacticalMap()
    {
        InitializeComponent();

        Global.Worker.OnGetDataFromServer += Worker_OnTurnRefresh;        
    }

    public void Initialization()
    {
        Logger.Info("Initialization finished");

        DrawBackgroundGrid();
    }

    Bitmap bitmapGrid;

    private void DrawBackgroundGrid()
    {
        bitmapGrid = new Bitmap(Width * 2, Height  * 2);

        var graphics = Graphics.FromImage(bitmapGrid);

        DrawStaticGridBackground.Execute(graphics, Global.ScreenData);
    }

    private void Worker_OnTurnRefresh(GameSessionData data)
    {
        if(isDrawInProcess) return;

        isDrawInProcess = true;

        CrossThreadExtensions.PerformSafely(this, RefreshControls, data);        

        isDrawInProcess = false;
    }

    private void RefreshControls(GameSessionData data)
    {
        var image = new Bitmap(Width, Height);

        var graphics = Graphics.FromImage(image);

        Draw.DrawTacticalMapScreen(graphics, data, Global.ScreenData, bitmapGrid);

        graphics.DrawString($"{DateTime.Now.Second}.{DateTime.Now.Millisecond}", new Font("Tahoma", 8), Brushes.White, new RectangleF(70, 90, 90, 50));

        imageTacticalMap.Image?.Dispose();
        imageTacticalMap.Image = image;

        graphics.Dispose();
    }
}
