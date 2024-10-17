namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawStaticGridBackground
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo)
    {
        var stopwatch = Stopwatch.StartNew();        

        var cellSize = UiTools.ZoomToCellSize(screenInfo.Zoom.Size);

        DrawGenericGrid(graphics, screenInfo, cellSize, Color.FromArgb(22, 22, 22));
        DrawGenericGrid(graphics, screenInfo, cellSize * 5, Color.FromArgb(32, 32, 32));
        DrawGenericGrid(graphics, screenInfo, cellSize * 25, Color.FromArgb(52, 52, 52));

        screenInfo.Metrics.LastGridDraw = DateTime.Now;
        screenInfo.Metrics.LastGridDrawTimeinMs = stopwatch.Elapsed.TotalMilliseconds;
    }

    private static void DrawGenericGrid(Graphics graphics, IScreenInfo screenInfo, int step, Color color)
    {
        var smallGridPen = new Pen(color);

        var stepsInScreenWidth = screenInfo.Width * 2 / step;
        var stepsInScreenHeight = screenInfo.Height * 2 / step;

        var mapTopLeftCorner = new Point(0, 0);

        for (var i = 0; i < stepsInScreenWidth; i++)
        {
            var lineFrom = new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y);
            var lineTo = new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y + screenInfo.Height * 2);

            graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
        }

        for (var i = 0; i < stepsInScreenHeight; i++)
        {
            var lineFrom = new PointF(mapTopLeftCorner.X, mapTopLeftCorner.Y + i * step);
            var lineTo = new PointF(mapTopLeftCorner.X + screenInfo.Width * 2, mapTopLeftCorner.Y + i * step);

            graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);
        }
    }
}
