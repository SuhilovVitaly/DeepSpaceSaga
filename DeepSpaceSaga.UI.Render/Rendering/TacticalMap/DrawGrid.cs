namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawGrid
{
    public static void Execute(IScreenInfo screenInfo)
    {       
        DrawGenericGrid(screenInfo, 50, new SpaceMapColor(Color.FromArgb(22, 22, 22)), GetLeftCorner(screenInfo));
        DrawGenericGrid(screenInfo, 250, new SpaceMapColor(Color.FromArgb(32, 32, 32)), GetLeftCorner(screenInfo));
    }

    private static void DrawGenericGrid(IScreenInfo screenInfo, int step, SpaceMapColor color, SpaceMapPoint corner)
    {

        var stepsInScreenWidth = screenInfo.Width * 2 / step;
        var stepsInScreenHeight = screenInfo.Height * 2 / step;

        var mapTopLeftCorner = corner;

        for (var i = 0; i < stepsInScreenWidth; i++)
        {
            var lineFrom = new SpaceMapPoint(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y);
            var lineTo = new SpaceMapPoint(mapTopLeftCorner.X + i * step, mapTopLeftCorner.Y + screenInfo.Height * 2);

            DrawTools.DrawLine(screenInfo, color, lineFrom, lineTo);
        }

        for (var i = 0; i < stepsInScreenHeight; i++)
        {
            var lineFrom = new SpaceMapPoint(mapTopLeftCorner.X, mapTopLeftCorner.Y + i * step);
            var lineTo = new SpaceMapPoint(mapTopLeftCorner.X + screenInfo.Width * 2, mapTopLeftCorner.Y + i * step);

            DrawTools.DrawLine(screenInfo, color, lineFrom, lineTo);
        }
    }

    internal static SpaceMapPoint GetLeftCorner(IScreenInfo screenInfo)
    {
        var xGridSize = (int)(screenInfo.Width / 2 / screenInfo.Zoom.Size) + 1;
        var yGridSize = (int)(screenInfo.Height / 2 / screenInfo.Zoom.Size) + 1;

        var offsetXfromCenterMap = screenInfo.CenterScreenOnMap.X % screenInfo.Zoom.Size;
        var offsetYfromCenterMap = screenInfo.CenterScreenOnMap.Y % screenInfo.Zoom.Size;

        var offsetXfromScreenSize = xGridSize * screenInfo.Zoom.Size;
        var offsetYfromScreenSize = yGridSize * screenInfo.Zoom.Size;

        var cornerX = screenInfo.CenterScreenOnMap.X - offsetXfromCenterMap - offsetXfromScreenSize;
        var cornerY = screenInfo.CenterScreenOnMap.Y - offsetYfromCenterMap - offsetYfromScreenSize;

        var corner = UiTools.ToScreenCoordinates(screenInfo, new SpaceMapPoint(cornerX, cornerY));

        return new SpaceMapPoint(corner.X, corner.Y);
    }
}