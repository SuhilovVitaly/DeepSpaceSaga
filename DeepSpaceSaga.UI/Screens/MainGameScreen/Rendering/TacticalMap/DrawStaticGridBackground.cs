namespace DeepSpaceSaga.UI.Screens.MainGameScreen.Rendering.TacticalMap;

internal class DrawStaticGridBackground
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo)
    {
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        DrawGenericGrid(graphics, screenInfo, 10, Color.FromArgb(12, 12, 12));
        DrawGenericGrid(graphics, screenInfo, 100, Color.FromArgb(28, 28, 28));
        DrawGenericGrid(graphics, screenInfo, 1000, Color.FromArgb(52, 52, 52));
    }

    private static void DrawGenericGrid(Graphics graphics, IScreenInfo screenInfo, int step, Color color)
    {
        var smallGridPen = new Pen(color);

        var stepsInScreenWidth = (screenInfo.Width * 2 / step);
        var stepsInScreenHeight = (screenInfo.Height * 2 / step);

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
