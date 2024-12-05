using DeepSpaceSaga.Common.Geometry;
using DeepSpaceSaga.UI.Render.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;
    private long drawDuration = 0;

    private readonly SKControl _skControl;

    public StellarTacticalMap()
    {
        InitializeComponent();

        _skControl = new SKControl
        {
            Dock = DockStyle.Fill,
            Visible = true
        };
        _skControl.PaintSurface += OnPaintSurface;
        _skControl.BringToFront();
        Controls.Add(_skControl);
        _skControl.BringToFront();

        imageTacticalMap.MouseClick += MapClick;
        imageTacticalMap.MouseMove += MapMouseMove;

        if (Global.GameManager == null) return;

        Global.GameManager.EventController.OnRefreshData += Worker_RefreshData;
        Global.GameManager.EventController.OnInitializeData += Worker_OnGameInitialize;
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

        Global.Resources.DrawTool.DrawTacticalMapScreen(session, Global.ScreenData);
    }

    private void RefreshControls(GameSession data)
    {
        _skControl.Invalidate();
        _skControl.Update();
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

        Global.GameManager.EventController.TacticalMapMouseClick(mouseLocation);
    }
}
