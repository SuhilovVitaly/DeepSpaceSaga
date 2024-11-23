namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class SpacecraftTelemetryControl : UserControl
{
    public SpacecraftTelemetryControl()
    {
        InitializeComponent();

        if (Global.Worker == null) return;

        Global.Worker.OnGetDataFromServer += Worker_RefreshData;
    }

    private void Worker_RefreshData(GameManager manager)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, manager);        
    }

    private void RefreshControls(GameManager manager)
    {
        var spacecraftLocation = manager.GetPlayerSpacecraft();

        crlSpacecraftName.Text = spacecraftLocation?.Name;
        crlDirection.Text = spacecraftLocation?.Direction + "";
        crlVelocity.Text = spacecraftLocation?.Speed + "";
        crlAgility.Text = spacecraftLocation?.Agility + "";
    }
}
