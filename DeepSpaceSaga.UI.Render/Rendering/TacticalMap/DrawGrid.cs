namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawGrid
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo)
    {       
        DrawGenericGrid(graphics, screenInfo, 50, Color.FromArgb(22, 22, 22), GetLeftCorner(screenInfo));
        DrawGenericGrid(graphics, screenInfo, 250, Color.FromArgb(32, 32, 32), GetLeftCorner(screenInfo));
    }

    private static void DrawGenericGrid(Graphics graphics, IScreenInfo screenInfo, int step, Color color, PointF corner)
    {
        var smallGridPen = new Pen(color);

        var stepsInScreenWidth = screenInfo.Width * 2 / step;
        var stepsInScreenHeight = screenInfo.Height * 2 / step;

        var mapTopLeftCorner = corner;

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

    public static void Execute(Graphics graphics, IScreenInfo screenInfo, Bitmap grid)
    {
        var staticGrid = (Bitmap)grid.Clone();

        graphics.DrawImage(staticGrid, GetLeftCorner(screenInfo));

        //graphics.FillEllipse(new SolidBrush(Color.Beige), screenInfo.Center.X - 2, screenInfo.Center.Y - 2, 4, 4);
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