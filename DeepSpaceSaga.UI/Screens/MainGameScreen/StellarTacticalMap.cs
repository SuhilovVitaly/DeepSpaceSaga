namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
    ScreenParameters screenParameters;

    private bool isDrawInProcess = false;

    public StellarTacticalMap()
    {
        InitializeComponent();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        screenParameters = new ScreenParameters(resolution.Width, resolution.Height);

        Global.Worker.OnGetDataFromServer += Worker_OnTurnRefresh;
    }

    public void Initialization()
    {
        Logger.Info("Initialization finished");
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

        Draw.DrawTacticalMapScreen(graphics, data, screenParameters);

        graphics.DrawString($"{DateTime.Now.Second}.{DateTime.Now.Millisecond}", new Font("Tahoma", 8), Brushes.White, new RectangleF(70, 90, 90, 50));

        imageTacticalMap.Image?.Dispose();
        imageTacticalMap.Image = image;

        graphics.Dispose();
    }
}
