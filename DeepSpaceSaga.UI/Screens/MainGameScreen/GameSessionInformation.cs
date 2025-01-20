namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class GameSessionInformation : ControlWindow
{
    public GameSessionInformation()
    {
        InitializeComponent();

        if (Global.GameManager is null) return;

        Global.GameManager.Events.OnRefreshData += Worker_RefreshData;
        Global.GameManager.Events.OnTacticalMapMouseMove += CrlTacticalMap_OnMouseMove;
    }

    private void Worker_RefreshData(GameSessionDTO session)
    {
        CrossThreadExtensions.PerformSafely(this, RereshControls, session);
    }

    private void RereshControls(GameSessionDTO session)
    {
        txtTurn.Text = $"{session.Metrics.Turn}.{session.Metrics.TurnTick} ({session.Metrics.TurnsTicks})";
        txtSpeed.Text = session.State.IsPaused ? "Pause" : session.State.Speed + "";
        txtCelestialObjects.Text = session.SpaceMap.Count() + "";
    }

    private void CrlTacticalMap_OnMouseMove(SpaceMapPoint e)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(Global.GameManager.Screens.Settings, e);
        crlGameCoordinates.Text = $"{(int)e.X} : {(int)e.Y}";
        crlScreenCoordinates.Text = $"{(int)screenCoordinates.X} : {(int)screenCoordinates.Y}";
    }
}
