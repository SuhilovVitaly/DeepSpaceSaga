﻿namespace DeepSpaceSaga.UI.Screens.MainGameScreen;

public partial class StellarTacticalMap : UserControl
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

    private bool isDrawInProcess = false;
    private long drawDuration = 0;

    public StellarTacticalMap()
    {
        InitializeComponent();

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

    private void RefreshControls(GameSession data)
    {
        var stopwatch = Stopwatch.StartNew();

        var image = new Bitmap(Width, Height);

        var graphics = Graphics.FromImage(image);

        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        Global.ScreenData =
                new ScreenParameters(Width, Height, (int)Global.ScreenData.CenterScreenOnMap.X, (int)Global.ScreenData.CenterScreenOnMap.Y)
                {
                    GraphicSurface = graphics
                };

        if(Global.ScreenData.IsPlayerSpacecraftCenterScreen)
        {
            var spacecraftLocation = Global.GameManager.GetCelestialMap().GetCelestialObjects().Where(x => x.OwnerId == 1).FirstOrDefault()?.GetLocation();

            if(spacecraftLocation != null)
            {
                Global.ScreenData =
                new ScreenParameters(Width, Height, (int)spacecraftLocation.Value.X, (int)spacecraftLocation.Value.Y)
                {
                    GraphicSurface = graphics
                };
            }            
        }        

        var session = Global.GameManager.GetSession();

        Global.Resources.DrawTool.DrawTacticalMapScreen(graphics, session, Global.ScreenData);

        Global.ScreenData.Metrics.PreRenderBaseGridsTimeinMs = stopwatch.ElapsedMilliseconds;

        if(drawDuration > 0)
        {
            drawDuration = (drawDuration + stopwatch.ElapsedMilliseconds) / 2;
        }
        else
        {
            drawDuration = stopwatch.ElapsedMilliseconds;
        }        

        graphics.DrawString($"Draw duration is {drawDuration} ms", new Font("Tahoma", 8), Brushes.White, new RectangleF(70, 90, 190, 50));

        imageTacticalMap.Image?.Dispose();
        imageTacticalMap.Image = image;
        graphics.Dispose();        
    }

    private void MapMouseMove(object sender, MouseEventArgs e)
    {
        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(e.Location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        Global.GameManager.EventController.TacticalMapMouseMove(mouseLocation);
    }
    private void MapClick(object sender, MouseEventArgs e)
    {
        var mouseScreenCoordinates = UiTools.ToRelativeCoordinates(e.Location, Global.ScreenData.Center);

        var mouseLocation = UiTools.ToTacticalMapCoordinates(mouseScreenCoordinates, Global.ScreenData.CenterScreenOnMap);

        Global.GameManager.EventController.TacticalMapMouseClick(mouseLocation);
    }
}
