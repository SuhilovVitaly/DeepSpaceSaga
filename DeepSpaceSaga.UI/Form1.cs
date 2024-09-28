namespace DeepSpaceSaga.UI;

public partial class Form1 : Form
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private int turnsCount = 0;
    private int ticksInTurn = 0;

    public Form1()
    {
        InitializeComponent();

        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

        UpdateStyles();

        Rectangle resolution = Screen.PrimaryScreen.Bounds;

        this.Width = resolution.Width;
        this.Height = resolution.Height;

        crlTacticalMap.Dock = DockStyle.Fill;

        Global.Worker.OnTurnRefresh += Worker_OnTurnRefresh;
        Global.Worker.OnGetDataFromServer += Worker_OnGetDataFromServer;
    }

    private void Worker_OnGetDataFromServer(GameSessionData obj)
    {
        ticksInTurn++;
        CrossThreadExtensions.PerformSafely(this, RefreshControls);
        //Logger.Debug($"{turnsCount}.{ticksInTurn}");
    }

    private void Worker_OnTurnRefresh(GameSessionData obj)
    {
        turnsCount++;
        ticksInTurn = 0;
        CrossThreadExtensions.PerformSafely(this, RefreshControls);            
    }

    private void RefreshControls()
    {
        crlLabelTurns.Text = $"{turnsCount}.{ticksInTurn}";            
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void crlRunButton_Click(object sender, EventArgs e)
    {
        Logger.Debug("Run global worker process");
        crlTacticalMap.Initialization();
        Global.Worker.Run();
    }
}
