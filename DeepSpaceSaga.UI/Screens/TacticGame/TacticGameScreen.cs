﻿namespace DeepSpaceSaga.UI;

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

        var selectedScreen = Screen.AllScreens[Global.GameManager.Screens.Settings.MonitorId];

        Location = selectedScreen.WorkingArea.Location;

        Width = (int)Global.GameManager.Screens.Settings.Width;
        Height = (int)Global.GameManager.Screens.Settings.Height;

        crlCommands.Location = new Point((Width / 2) - crlCommands.Width / 2, crlCommands.Location.Y);

        _gameManager.Events.OnShowCelestialObject += Event_ShowCelestialObject;
        _gameManager.Events.OnHideCelestialObject += Event_HideCelestialObject;
        _gameManager.Events.OnSelectCelestialObject += Event_SelectCelestialObject;
        _gameManager.Events.OnUnselectCelestialObject += Event_UnselectCelestialObject;

        _gameManager.Events.SetMainGameScreenReference(this);
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
        _gameManager.Events.Pause();
        _gameManager.Screens.ShowGameMenuScreen();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.Settings.CenterScreenOnMap = new SpaceMapPoint(Global.GameManager.Screens.Settings.CenterScreenOnMap.X + 100, Global.GameManager.Screens.Settings.CenterScreenOnMap.Y);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.Settings.CenterScreenOnMap = new SpaceMapPoint(Global.GameManager.Screens.Settings.CenterScreenOnMap.X, Global.GameManager.Screens.Settings.CenterScreenOnMap.Y + 100);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.Settings.CenterScreenOnMap = new SpaceMapPoint(Global.GameManager.Screens.Settings.CenterScreenOnMap.X + 1000, Global.GameManager.Screens.Settings.CenterScreenOnMap.Y);
    }

    private void CrlZoomIn_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.Settings.Zoom.In();
    }

    private void CrlZoomOut_Click(object sender, EventArgs e)
    {
        Global.GameManager.Screens.Settings.Zoom.Out();
    }

    private void crlResumeGame_Click(object sender, EventArgs e)
    {
        _gameManager.Events.Resume();
    }

    private void crlGamePause_Click(object sender, EventArgs e)
    {
        _gameManager.Events.Pause();
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
            case Keys.Escape:
                _gameManager.Events.Pause();
                _gameManager.Screens.ShowGameMenuScreen();
                break;

            case Keys.Subtract:
                _gameManager.Screens.Settings.Zoom.Out();
                break;

            case Keys.Add:
                _gameManager.Screens.Settings.Zoom.In();
                break;

            case Keys.Space:
                if (session.State.IsPaused)
                {
                    Global.GameManager.Events.Resume();
                }
                else
                {
                    Global.GameManager.Events.Pause();
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

        Global.GameManager.Events.Pause();
        controlItemsTransfer.BringToFront();
        controlItemsTransfer.Visible = true;
    }

    private void Event_OpenSpacecraftCargo(object sender, EventArgs e)
    {

    }

    private void crlQuickSave_Click(object sender, EventArgs e)
    {
        Global.GameManager.Events.Save();
    }

    private void crlQuickLoad_Click(object sender, EventArgs e)
    {
        Global.GameManager.Events.Load();
    }
}
