namespace DeepSpaceSaga.UI;

public partial class Form1 : Form
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
    

    public Form1()
    {
        InitializeComponent();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        Width = resolution.Width;
        Height = resolution.Height;

        crlTacticalMap.Dock = DockStyle.Fill;

        KeyPreview = true;
        KeyDown += Window_KeyDown;

        if (Global.GameManager == null) return;

        Global.GameManager.EventController.OnTacticalMapMouseMove += CrlTacticalMap_OnMouseMove;

        Global.GameManager.EventController.OnRefreshData += Worker_OnGetDataFromServer;
    }

    private void CrlTacticalMap_OnMouseMove(PointF e)
    {
        crlMousePosition.Text = $"({Width}:{Height}) - ({Width/2}:{Height/2}){Environment.NewLine}({e.X}:{e.Y})";
    }

    private void Worker_OnGetDataFromServer(GameSession obj)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls);
    }

    private void RefreshControls()
    {
        var lastGridReDrawData = $" time: {Global.ScreenData.Metrics.LastGridDrawTimeinMs}";
        var prerenderingGrids = $" time: {Global.ScreenData.Metrics.PreRenderBaseGridsTimeinMs}";


        crlLabelTurns.Text = $" Turn is {Global.GameManager.GetSession().Turn}.{Global.GameManager.GetSession().TurnTick} {Environment.NewLine} " +
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
    }

    private void CrlZoomOut_Click(object sender, EventArgs e)
    {
        Global.ScreenData.Zoom.Out();
    }

    private void crlResumeGame_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Resume();
    }

    private void crlGamePause_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Pause();
    }

    private void Window_KeyDown(object? sender, KeyEventArgs e)
    {
        _ = KeyDownAsync(e);
    }

    private async Task KeyDownAsync(KeyEventArgs e)
    {
        Logger.Debug($"Window_KeyDown - Handle the KeyDown event {e.KeyCode} ");

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        var session = Global.GameManager.GetSession();

        switch (e.KeyCode)
        {
            case Keys.S:
                if (session.IsRunning == false) return;
                break;

            case Keys.D:
                if (session.IsRunning == false) return;

                await Global.GameManager.ExecuteCommandAsync(new Command
                {
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.TurnRight,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;

            case Keys.A:
                if (session.IsRunning == false) return;
                await Global.GameManager.ExecuteCommandAsync(new Command{
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.TurnLeft,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;

            case Keys.W:
                if (session.IsRunning == false) return;
                break;
        }
    }
}
