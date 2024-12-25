namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CommandsControl : UserControl
{
    private int _selectedCelestialObjectId = 0;

    public CommandsControl()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;

        DisableCommands();
    }

    private void Worker_RefreshData(GameSession session)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, session);
    }

    private void DisableCommands()
    {
        DisableCommand(commandRotateToTarget);
        DisableCommand(commandSyncSpeedWithTarget);
        DisableCommand(commandSyncDirectionWithTarget);
        DisableCommand(commandHarvestAsteroid);        
    }

    private void ModulesByRangeEnable(int id)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();
        var target = Global.GameManager.GetCelestialObject(id);
        var distance = GeometryTools.Distance(spacecraft.GetLocation(), target.GetLocation());
        
        // Harvest asteroid
        var module = spacecraft.Module(Common.Universe.Equipment.Category.MiningLaser) as IMiningLaser;
        
        if (distance <= module.MiningRange)
        {
            if (commandHarvestAsteroid.Enabled == false)
            {
                EnableCommand(commandHarvestAsteroid);
            }
        }
        else
        {
            if (commandHarvestAsteroid.Enabled == true)
            {
                DisableCommand(commandHarvestAsteroid);
            }
        }
    }

    private void RefreshControls(GameSession manager)
    {
        if (Global.GameManager.OuterSpace.SelectedObjectId == 0)
        {
            DisableCommands();
            return;
        }

        if (Global.GameManager.OuterSpace.SelectedObjectId == _selectedCelestialObjectId)
        {
            // No need update commands status (Enabled/Disabled)
            ModulesByRangeEnable(_selectedCelestialObjectId);
            return;
        }

        _selectedCelestialObjectId = Global.GameManager.OuterSpace.SelectedObjectId;

        EnableCommand(commandRotateToTarget);
        EnableCommand(commandSyncSpeedWithTarget);
        EnableCommand(commandSyncDirectionWithTarget);
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

    private void Event_SyncSpeedWithTarget(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });
    }

    private void Event_RotateToTarget(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.RotateToTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });
    }

    private void crlFullSpeed_Click(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.FullSpeed,
            Status = CommandStatus.Process,
            IsOneTimeCommand = false,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });
    }

    private void crlFullStop_Click(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.StopShip,
            Status = CommandStatus.Process,
            IsOneTimeCommand = false,
            CelestialObjectId = spacecraft.Id,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });
    }

    private void Event_SyncDirectionWithTarget(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncDirectionWithTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });
    }

    private void Event_HarvestAsteroid(object sender, EventArgs e)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        var command = new Command
        {
            Category = CommandCategory.Mining,
            Type = CommandTypes.MiningOperationsHarvest,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.MiningLaser).Id
        };

        _ = Global.GameManager.ExecuteCommandAsync(command);
    }
}
