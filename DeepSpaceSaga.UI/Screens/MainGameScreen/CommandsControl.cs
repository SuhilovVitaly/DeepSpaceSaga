namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CommandsControl : UserControl
{
    private int _selectedCelestialObjectId = 0;

    public CommandsControl()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;

        DisableCommand(commandRotateToTarget);
        DisableCommand(commandCourseSyncToTarget);
    }

    private void Worker_RefreshData(GameSession session)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, session);
    }

    private void RefreshControls(GameSession manager)
    {
        if (Global.GameManager.OuterSpace.SelectedObjectId == 0)
        {
            DisableCommand(commandRotateToTarget);
            DisableCommand(commandCourseSyncToTarget);
            return;
        }

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

    private void DisableCommand(Button command)
    {
        command.Cursor = Cursors.Default;
        command.Enabled = false;
        command.ForeColor = Color.DimGray;
    }
}
