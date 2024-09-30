namespace DeepSpaceSaga.UI.Screens.MainGameScreen.Rendering.TacticalMap;

public class DrawGrid
{
    private static int GridSize = 1000;

    public static void Execute(Graphics graphics, IScreenInfo screenInfo, Bitmap grid)
    {
        var staticGrid = (Bitmap)grid.Clone();

        graphics.DrawImage(staticGrid, GetLeftCorner(screenInfo));

        graphics.FillEllipse(new SolidBrush(Color.Beige), screenInfo.Center.X - 2, screenInfo.Center.Y - 2, 4, 4);
    }

    private static PointF GetLeftCorner(IScreenInfo screenInfo)
    {
        var xGridSize = (int)(screenInfo.Width / 2 / GridSize) + 1;
        var yGridSize = (int)(screenInfo.Height / 2 / GridSize) + 1;

        var offsetXfromCenterMap = screenInfo.CenterScreenOnMap.X % GridSize;
        var offsetYfromCenterMap = screenInfo.CenterScreenOnMap.Y % GridSize;

        var offsetXfromScreenSize = xGridSize * GridSize;
        var offsetYfromScreenSize = yGridSize * GridSize;

        var cornerX = screenInfo.CenterScreenOnMap.X - offsetXfromCenterMap - offsetXfromScreenSize;
        var cornerY = screenInfo.CenterScreenOnMap.Y - offsetYfromCenterMap - offsetYfromScreenSize;

        var corner = UiTools.ToScreenCoordinates(screenInfo, new PointF(cornerX, cornerY));

        return new PointF(corner.X, corner.Y);
    }
}