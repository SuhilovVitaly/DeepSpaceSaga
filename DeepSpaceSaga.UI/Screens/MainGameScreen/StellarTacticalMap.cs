namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private bool isDrawInProcess = false;
    private readonly SKControl _skControl;
    IGameManager _gameManager;

    public StellarTacticalMap()
    {
        InitializeComponent();

        _skControl = new SKControl
        {
            Dock = DockStyle.Fill,
            Visible = true
        };

    }

    public void Initialization(IGameManager gameManager)
    {
        _gameManager = gameManager;

        if (_gameManager == null) return;
        
        _skControl.PaintSurface += OnPaintSurface;
        _skControl.BringToFront();
        Controls.Add(_skControl);
        _skControl.BringToFront();

        _skControl.MouseClick += MapClick;
        _skControl.MouseMove += MapMouseMove;

        _gameManager.Events.OnRefreshData += Worker_RefreshData;
        _gameManager.Events.OnInitializeData += Worker_OnGameInitialize;
        _gameManager.Events.OnShowCelestialObject += Event_ShowCelestialObject;
        _gameManager.Events.OnSelectCelestialObject += Event_SelectCelestialObject;
    }

    private void Event_SelectCelestialObject(ICelestialObject celestialObject)
    {
        
    }

    private void Event_ShowCelestialObject(ICelestialObject celestialObject)
    {
        
    }

    private void Worker_OnGameInitialize(GameSessionDTO manager)
    {
        RefreshControls(manager);
    }

    private void Worker_RefreshData(GameSessionDTO manager)
    {
        if (isDrawInProcess) return;

        isDrawInProcess = true;

        CrossThreadExtensions.PerformSafely(this, RefreshControls, manager);

        isDrawInProcess = false;
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;

        canvas.Clear(SKColors.Black);

        var session = Global.GameManager.GetSession();

        Global.GameManager.Screens.Settings.GraphicSurface = canvas;
        Global.GameManager.Screens.Settings.CenterScreenOnMap = session.GetPlayerSpaceShip().GetLocation();

        Global.Resources.DrawTool.DrawTacticalMapScreen(session, Global.GameManager.OuterSpace, Global.GameManager.Screens.Settings);
    }

    private void RefreshControls(GameSessionDTO data)
    {
        _skControl.Invalidate();
    }

    private void MapMouseMove(object sender, MouseEventArgs e)
    {
        var location = e.Location.ToSpaceMapCoordinates();

        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(location, Global.GameManager.Screens.Settings.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.GameManager.Screens.Settings.CenterScreenOnMap);

        _gameManager.Events.TacticalMapMouseMove(mouseLocation);
    }

    private void MapClick(object sender, MouseEventArgs e)
    {
        var location = e.Location.ToSpaceMapCoordinates();

        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(location, Global.GameManager.Screens.Settings.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.GameManager.Screens.Settings.CenterScreenOnMap);

        if(e.Button == MouseButtons.Left)
        {
            _gameManager.Events.TacticalMapMouseClick(mouseLocation);
        }

        if (e.Button == MouseButtons.Right)
        {
            _gameManager.Events.TacticalMapLeftMouseClick(mouseLocation);
        }
    }
}
