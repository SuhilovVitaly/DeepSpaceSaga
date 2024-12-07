namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CommandsControl : UserControl
{
    private int _selectedCelestialObjectId = 0;

    public CommandsControl()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;
    }

    private void Worker_RefreshData(GameSession session)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, session);
    }

    private void RefreshControls(GameSession manager)
    {
        if(Global.GameManager.OuterSpace.SelectedObjectId == _selectedCelestialObjectId) 
        {
            // No need update commands status (Enabled/Disabled)
            return;
        }

        _selectedCelestialObjectId = Global.GameManager.OuterSpace.SelectedObjectId;

        EnableCommand(commandRotateToTarget);
        EnableCommand(commandCourseSyncToTarget);
    }

    private void EnableCommand(Button command)
    {
        command.Cursor = Cursors.Hand;
        command.Enabled = true;
        command.ForeColor = Color.WhiteSmoke;
    }
}
