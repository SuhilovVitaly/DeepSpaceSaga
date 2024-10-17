namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawGrid
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo, Bitmap grid)
    {
        var staticGrid = (Bitmap)grid.Clone();

        graphics.DrawImage(staticGrid, GetLeftCorner(screenInfo));

        graphics.FillEllipse(new SolidBrush(Color.Beige), screenInfo.Center.X - 2, screenInfo.Center.Y - 2, 4, 4);
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