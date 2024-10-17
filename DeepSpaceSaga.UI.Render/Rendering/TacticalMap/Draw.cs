namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class Draw
{
    Dictionary<int, Bitmap> prerenderedGridsByZoom = new();

    public void Initialization(ScreenParameters screenParameters)
    {
        var stopwatch = Stopwatch.StartNew();

        // TODO: 
        var zoomModes = new ConcurrentBag<int> { 1 };

        foreach (var zoomMode in zoomModes)
        {
            AddPreRenderGrid(screenParameters, zoomMode);
            //prerenderedGridsByZoom[zoomMode].Save(Path.Combine(Environment.CurrentDirectory, zoomMode + ".png"), ImageFormat.Png);
        }


        //var zoomModes = new ConcurrentBag<int> { 4000, 2000, 1000, 500, 250, 200 };

        //Parallel.ForEach(zoomModes, zoom =>
        //{
        //    AddPreRenderGrid(screenParameters, zoom);
        //});


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

        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        DrawStaticGridBackground.Execute(graphics, screenParameters);

        return bitmapGrid;
    }

    public void DrawTacticalMapScreen(Graphics graphics, GameSessionData session, ScreenParameters screenParameters)
    {
        DrawGrid.Execute(graphics, screenParameters, prerenderedGridsByZoom[1]); // screenParameters.Zoom.Size
    }
}
