namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class LogbookControl : ControlWindow
{
    public LogbookControl()
    {
        InitializeComponent();

        if (Global.GameManager is null) return;

        Global.GameManager.Events.OnRefreshData += Worker_RefreshData;
    }

    private void Worker_RefreshData(GameSessionDTO session)
    {
        CrossThreadExtensions.PerformSafely(this, Refresh);
    }

    private void LogbookControl_Paint(object sender, PaintEventArgs e)
    {
        if (Global.GameManager is null) return;

        var session = Global.GameManager.GetSession();

        Graphics graphics = e.Graphics;

        using Font font = new Font("Tahoma", 8, FontStyle.Bold);
        using Brush brush = new SolidBrush(Color.WhiteSmoke);

        int row = 0;

        foreach (var item in session.Logbook.Where(x=> x.Type != Common.Universe.Audit.EventType.NavigationManeuver).OrderByDescending(x=>x.Id))
        {
            graphics.DrawString($"{item.Text} ", font, brush, new PointF(10, 10 + row * 12));
            row++;

            if(row > 10) break;
        }
    }
}
