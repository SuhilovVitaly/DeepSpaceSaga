namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class GameSessionInformation : ControlWindow
{
    public GameSessionInformation()
    {
        InitializeComponent();

        if (Global.GameManager is null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;
        Global.GameManager.EventController.OnTacticalMapMouseMove += CrlTacticalMap_OnMouseMove;
    }

    private void Worker_RefreshData(GameSession session)
    {
        CrossThreadExtensions.PerformSafely(this, RereshControls, session);
    }

    private void RereshControls(GameSession session)
    {
        txtTurn.Text = $"{session.Turn}.{session.TurnTick} ({session.TurnsTicks})";
        txtSpeed.Text = session.State.IsPaused ? "Pause" : session.State.Speed + "";
        txtCelestialObjects.Text = session.SpaceMap.Count() + "";
    }

    private void CrlTacticalMap_OnMouseMove(SpaceMapPoint e)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(Global.ScreenData, e);
        crlGameCoordinates.Text = $"{(int)e.X} : {(int)e.Y}";
        crlScreenCoordinates.Text = $"{(int)screenCoordinates.X} : {(int)screenCoordinates.Y}";
    }
}
