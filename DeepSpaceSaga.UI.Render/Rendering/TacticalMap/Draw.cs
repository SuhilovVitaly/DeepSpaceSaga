using DeepSpaceSaga.UI.Render.Model;

namespace DeepSpaceSaga.UI.Screens.MainGameScreen.Rendering.TacticalMap;

public class Draw
{
    Dictionary<int, Bitmap> prerenderedGridsByZoom = new();

    public void Initialization(ScreenParameters screenParameters)
    {
        var stopwatch = Stopwatch.StartNew();

        
        //var zoomModes = new ConcurrentBag<int> { 4000 };

        //foreach (var zoomMode in zoomModes)
        //{
        //    AddPreRenderGrid(screenParameters, zoomMode);
        //    prerenderedGridsByZoom[zoomMode].Save(Path.Combine( Environment.CurrentDirectory, zoomMode + ".png"), ImageFormat.Png);
        //}


        var zoomModes = new ConcurrentBag<int> { 4000, 2000, 1000, 500, 250, 200 };

        Parallel.ForEach(zoomModes, zoom =>
        {
            AddPreRenderGrid(screenParameters, zoom);
        });


        screenParameters.Metrics.PreRenderBaseGridsTimeinMs = stopwatch.Elapsed.TotalMilliseconds;
    }

    private void AddPreRenderGrid(ScreenParameters screenParameters, int zoomSize)
    {
        var screenParametersRebuilded = new ScreenParameters(screenParameters, zoomSize);
        prerenderedGridsByZoom.Add(screenParametersRebuilded.Zoom.Size, DrawBackgroundGridByZoom(screenParametersRebuilded));
    }

    private Bitmap DrawBackgroundGridByZoom(ScreenParameters screenParameters)
    {
        var bitmapGrid = new Bitmap((int)(screenParameters.Width * 2), (int)(screenParameters.Height * 2));

        var graphics = Graphics.FromImage(bitmapGrid);

        DrawStaticGridBackground.Execute(graphics, screenParameters);

        return bitmapGrid;
    }

    public void DrawTacticalMapScreen(Graphics graphics, GameSessionData session, ScreenParameters screenParameters)
    {
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        prerenderedGridsByZoom[4000].Save(Path.Combine(Environment.CurrentDirectory, "4000_1.png"), ImageFormat.Png);

        DrawGrid.Execute(graphics, screenParameters, prerenderedGridsByZoom[screenParameters.Zoom.Size]);
    }
}
