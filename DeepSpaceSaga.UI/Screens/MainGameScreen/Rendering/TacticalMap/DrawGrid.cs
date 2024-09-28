namespace DeepSpaceSaga.UI.Screens.MainGameScreen.Rendering.TacticalMap;

public class DrawGrid
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo)
    {
        try
        {
            //var scale = screenInfo.Settings.Scale;

            DrawGridBasicZones(graphics, screenInfo, 5, Color.FromArgb(8, 8, 8));
            DrawGridBasicZones(graphics, screenInfo, 50, Color.FromArgb(18, 18, 18));
        }
        catch
        {

        }
    }

    private static void DrawGridBasicZones(Graphics graphics, IScreenInfo screenInfo, int step, Color color)
    {
        var smallGridPen = new Pen(color);

        var offsetX = step * 2;
        var offsetY = step * 2;

        var stepsInScreenWidth = screenInfo.Width / step;
        var stepsInScreenHeight = screenInfo.Height / step;

        var mapTopLeftCorner = new Point(
            (int)(Math.Round((screenInfo.CenterScreenOnMap.X - screenInfo.Width / 2) / step) * step),
            (int)(Math.Round((screenInfo.CenterScreenOnMap.Y - screenInfo.Height / 2) / step) * step));

        for (var i = 0; i < stepsInScreenWidth; i++)
        {
            var lineFrom = UiTools.ToScreenCoordinates(screenInfo, new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y - offsetY));
            var lineTo = UiTools.ToScreenCoordinates(screenInfo, new PointF(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y + screenInfo.Height));

            graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);

        }

        for (var i = 0; i < stepsInScreenHeight; i++)
        {
            var lineFrom = UiTools.ToScreenCoordinates(screenInfo, new PointF(mapTopLeftCorner.X - offsetX, mapTopLeftCorner.Y + i * step));
            var lineTo = UiTools.ToScreenCoordinates(screenInfo, new PointF(mapTopLeftCorner.X + screenInfo.Width, mapTopLeftCorner.Y + i * step));

            graphics.DrawLine(smallGridPen, lineFrom.X, lineFrom.Y, lineTo.X, lineTo.Y);

        }
    }
}