namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class SpacecraftTelemetryControl : UserControl
{
    public SpacecraftTelemetryControl()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        Global.GameManager.Events.OnRefreshData += Worker_RefreshData;
    }

    private void Worker_RefreshData(GameSession manager)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, manager);        
    }

    private void RefreshControls(GameSession manager)
    {
        var spacecraftLocation = Global.GameManager.GetPlayerSpacecraft();

        crlSpacecraftName.Text = spacecraftLocation?.Name;
        crlDirection.Text = spacecraftLocation?.Direction + "";
        crlVelocity.Text = spacecraftLocation?.Speed + "";
        crlAgility.Text = spacecraftLocation?.Agility + "";
    }
}
