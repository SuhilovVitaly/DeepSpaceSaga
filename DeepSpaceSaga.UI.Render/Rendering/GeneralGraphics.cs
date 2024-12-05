namespace DeepSpaceSaga.UI.Render.Rendering;

internal class GeneralGraphics
{
    public static void DrawArrow(IScreenInfo screenInfo, SpaceMapVector line, SpaceMapColor color, int arrowSize = 4)
    {
        // Base arrow line
        DrawTools.DrawLine(screenInfo, color, line.PointFrom, line.PointTo);

        // Arrow left line
        var leftArrowLine = GeometryTools.Move(line.PointTo, arrowSize, line.Direction + 150);
        DrawTools.DrawLine(screenInfo, color, line.PointTo, leftArrowLine);

        // Arrow right line
        var rightArrowLine = GeometryTools.Move(line.PointTo, arrowSize, line.Direction - 150);
        DrawTools.DrawLine(screenInfo, color, line.PointTo, rightArrowLine);
    }

    public static void DrawArrow(IScreenInfo screenInfo, ICelestialObject currentObject, SpaceMapColor color, int arrowLength = 16, int arrowSize = 5)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, currentObject.GetLocation());

        var endArrowPoint = GeometryTools.Move(screenCoordinates, arrowLength, currentObject.Direction);

        DrawArrow(screenInfo, new SpaceMapVector(screenCoordinates, endArrowPoint, currentObject.Direction), color, arrowSize);
    }

    public static void DrawLongLine(IScreenInfo screenInfo, ICelestialObject currentObject, SpaceMapColor color)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, currentObject.GetLocation());

        var line = new SpaceMapVector(
            screenCoordinates,
            GeometryTools.Move(screenCoordinates, 4000, currentObject.Direction),
            currentObject.Direction);

        using var gridPaint = new SKPaint
        {
            Color = color.ToSKColor(),
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        DrawTools.DrawLine(screenInfo, color, line.PointTo, line.PointFrom);

        if (currentObject.Types == CelestialObjectTypes.Asteroid)
        {
            line = new SpaceMapVector(
            screenCoordinates,
            GeometryTools.Move(screenCoordinates, 4000, (currentObject.Direction - 180).To360Degrees()),
            currentObject.Direction);

            DrawTools.DrawLine(screenInfo, color, line.PointFrom, line.PointTo);
        }
    }
}
