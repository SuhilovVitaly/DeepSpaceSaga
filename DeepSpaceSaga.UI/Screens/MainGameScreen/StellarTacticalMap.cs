namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private bool isDrawInProcess = false;
    private readonly SKControl _skControl;

    public StellarTacticalMap()
    {
        InitializeComponent();

        if (Global.GameManager == null) return;

        _skControl = new SKControl
        {
            Dock = DockStyle.Fill,
            Visible = true
        };
        _skControl.PaintSurface += OnPaintSurface;
        _skControl.BringToFront();
        Controls.Add(_skControl);
        _skControl.BringToFront();

        _skControl.MouseClick += MapClick;
        _skControl.MouseMove += MapMouseMove;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;
        Global.GameManager.EventController.OnInitializeData += Worker_OnGameInitialize;
        Global.GameManager.EventController.OnShowCelestialObject += Event_ShowCelestialObject;
        Global.GameManager.EventController.OnSelectCelestialObject += Event_SelectCelestialObject;
    }

    private void Event_SelectCelestialObject(ICelestialObject celestialObject)
    {
        
    }

    private void Event_ShowCelestialObject(ICelestialObject celestialObject)
    {
        
    }

    private void Worker_OnGameInitialize(GameSession manager)
    {
        RefreshControls(manager);
    }

    private void Worker_RefreshData(GameSession manager)
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

        Global.ScreenData.GraphicSurface = canvas;
        Global.ScreenData.CenterScreenOnMap = session.GetPlayerSpaceShip().GetLocation();

        Global.Resources.DrawTool.DrawTacticalMapScreen(session, Global.GameManager.OuterSpace, Global.ScreenData);
    }

    private void RefreshControls(GameSession data)
    {
        _skControl.Invalidate();
    }

    private void MapMouseMove(object sender, MouseEventArgs e)
    {
        var location = e.Location.ToSpaceMapCoordinates();

        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        Global.GameManager.EventController.TacticalMapMouseMove(mouseLocation);
    }

    private void MapClick(object sender, MouseEventArgs e)
    {
        var location = e.Location.ToSpaceMapCoordinates();

        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        if(e.Button == MouseButtons.Left)
        {
            Global.GameManager.EventController.TacticalMapMouseClick(mouseLocation);
        }

        if (e.Button == MouseButtons.Right)
        {
            Global.GameManager.EventController.TacticalMapLeftMouseClick(mouseLocation);
        }
    }
}
