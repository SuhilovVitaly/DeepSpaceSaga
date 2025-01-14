namespace DeepSpaceSaga.UI;

public partial class TacticGameScreen : Form
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(TacticGameScreen));

    private readonly ItemsContainer controlItemsContainer = new();
    private readonly ScreenItemsTransfer controlItemsTransfer = new();
    IGameManager _gameManager;

    public void Initialization()
    {
        _gameManager = Program.ServiceProvider.GetService<IGameManager>();

        crlTacticalMap.Initialization(_gameManager);

        panel1.Controls.Add(controlItemsContainer);
        panel1.Controls.Add(controlItemsTransfer);

        var selectedScreen = Screen.AllScreens[Global.ScreenData.MonitorId];

        Location = selectedScreen.WorkingArea.Location;

        Width = (int)Global.ScreenData.Width;
        Height = (int)Global.ScreenData.Height;

        crlCommands.Location = new Point((Width / 2) - crlCommands.Width / 2, crlCommands.Location.Y);

        _gameManager.EventController.OnShowCelestialObject += Event_ShowCelestialObject;
        _gameManager.EventController.OnHideCelestialObject += Event_HideCelestialObject;
        _gameManager.EventController.OnSelectCelestialObject += Event_SelectCelestialObject;
        _gameManager.EventController.OnUnselectCelestialObject += Event_UnselectCelestialObject;

        _gameManager.EventController.SetMainGameScreenReference(this);
    }

    public TacticGameScreen()
    {
        InitializeComponent();

        ActiveControl = null;

        crlTacticalMap.Dock = DockStyle.Fill;

        KeyPreview = true;
        KeyDown += Window_KeyDown;
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
        _gameManager.EventController.Pause();
        _gameManager.Screens.ShowGameMenuScreen();
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
        _gameManager.EventController.Resume();
    }

    private void crlGamePause_Click(object sender, EventArgs e)
    {
        _gameManager.EventController.Pause();
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
        try
        {
            CrossThreadExtensions.PerformSafely(this, EventOpenCargoUI, gameActionEvent);
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public void EventOpenCargoUI(GameActionEvent gameActionEvent)
    {
        //if (Global.GameManager.GetSession().State.IsPaused) return;

        var session = Global.GameManager.GetSession();

        var spacecraft = session.GetPlayerSpaceShip();

        controlItemsTransfer.Visible = false;
        if (controlItemsTransfer.Location == new Point(0, 0))
        {
            controlItemsTransfer.Location = new Point((Width / 2) - controlItemsTransfer.Width / 2, (Height / 2) - controlItemsTransfer.Height / 2);
        }
        var cargo = spacecraft.GetModules(Common.Universe.Equipment.Category.CargoUnit).FirstOrDefault();

        var targetObject = session.GetCelestialObject((long)gameActionEvent.TargetObjectId) as IAsteroid;
        // TODO: Extract CargoContainer by type
        controlItemsTransfer.ShowTransfer(spacecraft, cargo.Id, spacecraft.Id, session, targetObject, targetObject.CoreContainer);

        Global.GameManager.EventController.Pause();
        controlItemsTransfer.BringToFront();
        controlItemsTransfer.Visible = true;
    }

    private void Event_OpenSpacecraftCargo(object sender, EventArgs e)
    {
        //var session = Global.GameManager.GetSession();

        //var spacecraft = session.GetPlayerSpaceShip();

        //if (spacecraft is null) return;

        //controlItemsTransfer.Visible = false;
        //if (controlItemsTransfer.Location == new Point(0, 0))
        //{
        //    controlItemsTransfer.Location = new Point((Width / 2) - controlItemsTransfer.Width / 2, (Height / 2) - controlItemsTransfer.Height / 2);           
        //}

        //var cargo = spacecraft.GetModules(Common.Universe.Equipment.Category.CargoUnit).FirstOrDefault();

        //controlItemsTransfer.ShowTransfer(spacecraft, cargo.Id, spacecraft.Id, session);

        //Global.GameManager.EventController.Pause();
        //controlItemsTransfer.BringToFront();
        //controlItemsTransfer.Visible = true;
    }

    private void crlQuickSave_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Save();
    }

    private void crlQuickLoad_Click(object sender, EventArgs e)
    {
        Global.GameManager.EventController.Load();
    }
}
