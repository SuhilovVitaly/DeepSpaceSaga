namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class CommandsControl : UserControl
{
    private int _selectedCelestialObjectId = 0;

    public CommandsControl(IEventManager events)
    {

    }

    public CommandsControl()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        Global.GameManager.Events.OnRefreshData += Worker_RefreshData;

        button14.Enabled = true;
        button14.BackColor = Color.Black;

        button14.Image = Image.FromFile(@"Images/Toolbar/Cargo.png");

        DisableCommands();


        foreach (Control control in this.Controls)
        {
            if (control is Button)
            {
                control.Click += (s, ev) => this.ActiveControl = null; 
            }
        }
    }

    private void Worker_RefreshData(GameSessionDTO session)
    {
        CrossThreadExtensions.PerformSafely(this, RefreshControls, session);
    }

    private void DisableCommands()
    {
        DisableCommand(commandRotateToTarget);
        DisableCommand(commandSyncSpeedWithTarget);
        DisableCommand(commandSyncDirectionWithTarget);
        DisableCommand(commandHarvestAsteroid);
        DisableCommand(commandOpenContainer);
    }

    private void ModulesByRangeEnable(int id)
    {
        var spacecraft = Global.GameManager.GetPlayerSpacecraft();
        var target = Global.GameManager.GetCelestialObject(id);

        if (target is null)
        {
            // Lost selected target object
            DisableCommands();
            return;
        }

        if (target.Types != CelestialObjectTypes.Asteroid)
        {
            DisableCommand(commandHarvestAsteroid);
            DisableCommand(commandOpenContainer);
            return;
        }

        var distance = GeometryTools.Distance(spacecraft.GetLocation(), target.GetLocation());

        // Harvest asteroid
        var module = spacecraft.Module(Common.Universe.Equipment.Category.MiningLaser) as IMiningLaser;

        if (distance <= module.MiningRange)
        {
            if (commandHarvestAsteroid.Enabled == false)
            {
                EnableCommand(commandHarvestAsteroid);
            }

            if (commandOpenContainer.Enabled == false)
            {
                EnableCommand(commandOpenContainer);
            }
        }
        else
        {
            if (commandHarvestAsteroid.Enabled == true)
            {
                DisableCommand(commandHarvestAsteroid);
            }

            if (commandOpenContainer.Enabled == true)
            {
                DisableCommand(commandOpenContainer);
            }
        }
    }

    private void RefreshControls(GameSessionDTO manager)
    {

        if (Global.GameManager.SpaceEnvironment.SelectedObjectId == 0)
        {
            DisableCommands();
            return;
        }

        if (Global.GameManager.SpaceEnvironment.SelectedObjectId == _selectedCelestialObjectId)
        {
            // No need update commands status (Enabled/Disabled)
            ModulesByRangeEnable(_selectedCelestialObjectId);
            return;
        }

        _selectedCelestialObjectId = Global.GameManager.SpaceEnvironment.SelectedObjectId;

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
        ActiveControl = null;

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncSpeedWithTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });

        Focus();
    }

    private void Event_RotateToTarget(object sender, EventArgs e)
    {
        ActiveControl = null;

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.RotateToTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });

        Focus();
    }

    private void crlFullSpeed_Click(object sender, EventArgs e)
    {
        ActiveControl = null;

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

        Focus();
    }

    private void crlFullStop_Click(object sender, EventArgs e)
    {
        ActiveControl = null;

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

        Focus();
    }

    private void Event_SyncDirectionWithTarget(object sender, EventArgs e)
    {
        ActiveControl = null;

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        _ = Global.GameManager.ExecuteCommandAsync(new Command
        {
            Category = CommandCategory.Navigation,
            Type = CommandTypes.SyncDirectionWithTarget,
            CelestialObjectId = spacecraft.Id,
            TargetCelestialObjectId = _selectedCelestialObjectId,
            ModuleId = spacecraft.Module(Common.Universe.Equipment.Category.Propulsion).Id
        });

        Focus();
    }

    private void Event_HarvestAsteroid(object sender, EventArgs e)
    {
        ActiveControl = null;

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

        Focus();
    }

    private void button14_Click(object sender, EventArgs e)
    {
        ActiveControl = null;

        Focus();
    }

    private void Event_OpenContainer(object sender, EventArgs e)
    {
        ActiveControl = null;

        var eventMessage = new GameActionEvent
        {
            Id = IdGenerator.GetNextId(),
            CelestialObjectId =Global.GameManager.GetPlayerSpacecraft().Id,
            TargetObjectId = Global.GameManager.SpaceEnvironment.SelectedObjectId
        };


        Global.GameManager.Events.ItemsTransferScreenShow(eventMessage);

        Focus();
    }
}
