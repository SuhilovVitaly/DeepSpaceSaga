namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawGrid
{
    public static void Execute(IScreenInfo screenInfo)
    {       
        DrawGenericGrid(screenInfo.GraphicSurface, screenInfo, 50, Color.FromArgb(22, 22, 22), GetLeftCorner(screenInfo));
        DrawGenericGrid(screenInfo.GraphicSurface, screenInfo, 250, Color.FromArgb(32, 32, 32), GetLeftCorner(screenInfo));
    }

    private static void DrawGenericGrid(SKCanvas graphics, IScreenInfo screenInfo, int step, Color color, PointF corner)
    {
        var smallGridPen = new SKColor(color.R, color.G, color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        var stepsInScreenWidth = screenInfo.Width * 2 / step;
        var stepsInScreenHeight = screenInfo.Height * 2 / step;

        var mapTopLeftCorner = corner;

        for (var i = 0; i < stepsInScreenWidth; i++)
        {
            var lineFrom = new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y);
            var lineTo = new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y + screenInfo.Height * 2);

            graphics.DrawLine(lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y, gridPaint);
        }

        for (var i = 0; i < stepsInScreenHeight; i++)
        {
            var lineFrom = new PointF(mapTopLeftCorner.X, mapTopLeftCorner.Y + i * step);
            var lineTo = new PointF(mapTopLeftCorner.X + screenInfo.Width * 2, mapTopLeftCorner.Y + i * step);

            graphics.DrawLine(lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y, gridPaint);
        }
    }

    internal static PointF GetLeftCorner(IScreenInfo screenInfo)
    {
        var xGridSize = (int)(screenInfo.Width / 2 / screenInfo.Zoom.Size) + 1;
        var yGridSize = (int)(screenInfo.Height / 2 / screenInfo.Zoom.Size) + 1;

        var offsetXfromCenterMap = screenInfo.CenterScreenOnMap.X % screenInfo.Zoom.Size;
        var offsetYfromCenterMap = screenInfo.CenterScreenOnMap.Y % screenInfo.Zoom.Size;

        var offsetXfromScreenSize = xGridSize * screenInfo.Zoom.Size;
        var offsetYfromScreenSize = yGridSize * screenInfo.Zoom.Size;

        var cornerX = screenInfo.CenterScreenOnMap.X - offsetXfromCenterMap - offsetXfromScreenSize;
        var cornerY = screenInfo.CenterScreenOnMap.Y - offsetYfromCenterMap - offsetYfromScreenSize;

        var corner = UiTools.ToScreenCoordinates(screenInfo, new PointF(cornerX, cornerY));

        return new PointF(corner.X, corner.Y);
    }
}