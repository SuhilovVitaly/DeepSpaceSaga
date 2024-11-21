namespace DeepSpaceSaga.UI;

public partial class Form1 : Form
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private GameSessionData gameSessionData;

    public Form1()
    {
        InitializeComponent();

        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

        UpdateStyles();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        this.Width = resolution.Width;
        this.Height = resolution.Height;

        crlTacticalMap.Dock = DockStyle.Fill;

        Global.Worker.OnGetDataFromServer += Worker_OnGetDataFromServer;
    }

    private void Worker_OnGetDataFromServer(GameSessionData obj)
    {
        gameSessionData = obj;
        CrossThreadExtensions.PerformSafely(this, RefreshControls);
    }

    private void RefreshControls()
    {
        var lastGridReDrawData = $" time: {Global.ScreenData.Metrics.LastGridDrawTimeinMs}";
        var prerenderingGrids = $" time: {Global.ScreenData.Metrics.PreRenderBaseGridsTimeinMs}";


        crlLabelTurns.Text = $" Turn is {gameSessionData.Turn}.{gameSessionData.TurnTick} {Environment.NewLine} " +
            $"Center is ({Global.ScreenData.CenterScreenOnMap.X},{Global.ScreenData.CenterScreenOnMap.Y}) {Environment.NewLine}" +
            $"Zoom is {Global.ScreenData.Zoom.Size} {Environment.NewLine}" +
            $"Prerendering is {prerenderingGrids} {Environment.NewLine}" +
            $"Grid Redraw info is {lastGridReDrawData} {Environment.NewLine}";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new PointF(Global.ScreenData.CenterScreenOnMap.X + 100, Global.ScreenData.CenterScreenOnMap.Y);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new PointF(Global.ScreenData.CenterScreenOnMap.X, Global.ScreenData.CenterScreenOnMap.Y + 100);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new PointF(Global.ScreenData.CenterScreenOnMap.X + 1000, Global.ScreenData.CenterScreenOnMap.Y);
    }

    private void CrlZoomIn_Click(object sender, EventArgs e)
    {
        Global.ScreenData.Zoom.In();
        //crlTacticalMap.Initialization();
    }

    private void CrlZoomOut_Click(object sender, EventArgs e)
    {
        Global.ScreenData.Zoom.Out();
    }

    private void crlResumeGame_Click(object sender, EventArgs e)
    {
        Global.Worker.Resume();
    }

    private void crlGamePause_Click(object sender, EventArgs e)
    {
        Global.Worker.Pause();
    }
}
