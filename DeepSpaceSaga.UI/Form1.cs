namespace DeepSpaceSaga.UI;

public partial class Form1 : Form
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private ItemsContainer controlItemsContainer = new ItemsContainer();
    private SpacecraftCargo controlSpacecraftCargo = new SpacecraftCargo();

    public Form1()
    {
        InitializeComponent();

        ActiveControl = null;

        crlTacticalMap.Dock = DockStyle.Fill;

        KeyPreview = true;
        KeyDown += Window_KeyDown;

        if (Global.GameManager == null) return;

        panel1.Controls.Add(controlItemsContainer);
        panel1.Controls.Add(controlSpacecraftCargo);

        var selectedScreen = Screen.AllScreens[Global.ScreenData.MonitorId];

        Location = selectedScreen.WorkingArea.Location;

        Width = (int)Global.ScreenData.Width;
        Height = (int)Global.ScreenData.Height;

        crlCommands.Location = new Point((Width / 2) - crlCommands.Width / 2, crlCommands.Location.Y);

        Global.GameManager.EventController.OnShowCelestialObject += Event_ShowCelestialObject;
        Global.GameManager.EventController.OnHideCelestialObject += Event_HideCelestialObject;
        Global.GameManager.EventController.OnSelectCelestialObject += Event_SelectCelestialObject;
        Global.GameManager.EventController.OnUnselectCelestialObject += Event_UnselectCelestialObject;

        Global.GameManager.EventController.SetMainGameScreenReference(this);
    }

    private void Event_UnselectCelestialObject(ICelestialObject @object)
    {
        crlSelectedCelestialObjectInfo.RefreshInfo(null);
    }

    private void Event_HideCelestialObject(ICelestialObject celestialObject)
    {
        crlActiveCelestialObjectInfo.RefreshInfo(celestialObject);
    }

    private void Event_SelectCelestialObject(ICelestialObject celestialObject)
    {
        crlSelectedCelestialObjectInfo.RefreshInfo(celestialObject);
    }

    private void Event_ShowCelestialObject(ICelestialObject celestialObject)
    {
        crlActiveCelestialObjectInfo.RefreshInfo(celestialObject);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Global.Cleanup();
        Application.Exit();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new SpaceMapPoint(Global.ScreenData.CenterScreenOnMap.X + 100, Global.ScreenData.CenterScreenOnMap.Y);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new SpaceMapPoint(Global.ScreenData.CenterScreenOnMap.X, Global.ScreenData.CenterScreenOnMap.Y + 100);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Global.ScreenData.CenterScreenOnMap = new SpaceMapPoint(Global.ScreenData.CenterScreenOnMap.X + 1000, Global.ScreenData.CenterScreenOnMap.Y);
    }

    private void CrlZoomIn_Click(object sender, EventArgs e)
    {
        Global.ScreenData.Zoom.In();
    }

    private void CrlZoomOut_Click(object sender, EventArgs e)
    {
        Global.ScreenData.Zoom.Out();
    }

    private void crlResumeGame_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Resume();
    }

    private void crlGamePause_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Pause();
    }

    private void Window_KeyDown(object? sender, KeyEventArgs e)
    {
        _ = KeyDownAsync(e);
    }

    private async Task KeyDownAsync(KeyEventArgs e)
    {
        Logger.Debug($"Window_KeyDown - Handle the KeyDown event {e.KeyCode} ");

        var spacecraft = Global.GameManager.GetPlayerSpacecraft();

        var session = Global.GameManager.GetSession();

        switch (e.KeyCode)
        {
            case Keys.Space:
                if (session.State.IsPaused)
                {
                    Global.GameManager.EventController.Resume();
                }
                else
                {
                    Global.GameManager.EventController.Pause();
                }
                break;
            case Keys.S:
                if (session.State.IsPaused) return;

                await Global.GameManager.ExecuteCommandAsync(new Command
                {
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.DecreaseShipSpeed,
                    IsOneTimeCommand = true,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;

            case Keys.D:
                if (session.State.IsPaused) return;

                await Global.GameManager.ExecuteCommandAsync(new Command
                {
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.TurnRight,
                    IsOneTimeCommand = true,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;

            case Keys.A:
                if (session.State.IsPaused) return;
                await Global.GameManager.ExecuteCommandAsync(new Command
                {
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.TurnLeft,
                    IsOneTimeCommand = true,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;

            case Keys.W:
                if (session.State.IsPaused) return;
                await Global.GameManager.ExecuteCommandAsync(new Command
                {
                    Category = CommandCategory.Navigation,
                    Type = CommandTypes.IncreaseShipSpeed,
                    IsOneTimeCommand = true,
                    CelestialObjectId = spacecraft.Id,
                    ModuleId = spacecraft.GetModules(Common.Universe.Equipment.Category.Propulsion).FirstOrDefault().Id
                });
                break;
        }
    }

    public void OpenCargoUI(GameActionEvent gameActionEvent)
    {
        CrossThreadExtensions.PerformSafely(this, EventOpenCargoUI, gameActionEvent);
    }

    public void EventOpenCargoUI(GameActionEvent gameActionEvent)
    {
        if (Global.GameManager.GetSession().State.IsPaused) return;

        var session = Global.GameManager.GetSession();

        
        controlItemsContainer.ShowContainer(gameActionEvent, session);
        controlItemsContainer.Visible = false;
        controlItemsContainer.Location = new Point(600, 600);
        
        Logger.Info($"Event id: {gameActionEvent.Id} ");
        Global.GameManager.EventController.Pause();
        controlItemsContainer.BringToFront();
        controlItemsContainer.Visible = true;

        var spacecraft = session.GetCelestialObject((long)gameActionEvent.CelestialObjectId) as ISpacecraft;

        if (spacecraft is null) return;
    }

    private void Event_OpenSpacecraftCargo(object sender, EventArgs e)
    {
        var session = Global.GameManager.GetSession();

        var spacecraft = session.GetPlayerSpaceShip();

        if (spacecraft is null) return;

        var gameActionEvent = new GameActionEvent
        {
            CelestialObjectId = spacecraft.Id,
            //TargetObjectId
        };


        //controlItemsContainer.ShowContainer(gameActionEvent, session);
        controlSpacecraftCargo.Visible = false;
        if (controlSpacecraftCargo.Location == new Point(0, 0))
        {
            controlSpacecraftCargo.Location = new Point((Width / 2) - controlSpacecraftCargo.Width / 2, (Height / 2) - controlSpacecraftCargo.Height / 2);           
        }
        
        controlSpacecraftCargo.ShowCargo();
        Global.GameManager.EventController.Pause();
        controlSpacecraftCargo.BringToFront();
        controlSpacecraftCargo.Visible = true;

        foreach (var control in panel1.Controls)
        {
            var x = control.GetType();
        }

    }
}
