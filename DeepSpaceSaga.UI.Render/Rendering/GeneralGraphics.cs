using DeepSpaceSaga.UI.Render.Extensions;

namespace DeepSpaceSaga.UI.Render.Rendering;

internal class GeneralGraphics
{
    public static void DrawArrow(SKCanvas graphics, SpaceMapVector line, Color color, int arrowSize = 4)
    {
        // Base arrow line
        graphics?.DrawLine(new Pen(color), line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);

        // Arrow left line
        var leftArrowLine = GeometryTools.Move(line.PointTo, arrowSize, line.Direction + 150);
        graphics?.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, leftArrowLine.X, leftArrowLine.Y);

        // Arrow right line
        var rightArrowLine = GeometryTools.Move(line.PointTo, arrowSize, line.Direction - 150);
        graphics?.DrawLine(new Pen(color), line.PointTo.X, line.PointTo.Y, rightArrowLine.X, rightArrowLine.Y);

    }

    public static void DrawArrow(IScreenInfo screenInfo, ICelestialObject currentObject, Color color, int arrowLength = 22, int arrowSize = 5)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, currentObject.GetLocation());

        var endArrowPoint = GeometryTools.Move(screenCoordinates, arrowLength, currentObject.Direction);

        DrawArrow(screenInfo.GraphicSurface, new SpaceMapVector(screenCoordinates, endArrowPoint, currentObject.Direction), color, arrowSize);
    }

    public static void DrawLongLine(IScreenInfo screenInfo, ICelestialObject currentObject, Color color)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, currentObject.GetLocation());

        var line = new SpaceMapVector(
            screenCoordinates,
            GeometryTools.Move(screenCoordinates, 4000, currentObject.Direction),
            currentObject.Direction);

        using var dashedPen = new Pen(color, 2) { DashStyle = DashStyle.DashDot };

        using var gridPaint = new SKPaint
        {
            Color = new SKColor(dashedPen.Color.R, dashedPen.Color.G, dashedPen.Color.B),
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        screenInfo.GraphicSurface.DrawLine(line.PointFrom.ToSkPoint(), line.PointTo.ToSkPoint(), gridPaint);

        if (currentObject.Types == CelestialObjectTypes.Asteroid)
        {
            line = new SpaceMapVector(
            screenCoordinates,
            GeometryTools.Move(screenCoordinates, 4000, (currentObject.Direction - 180).To360Degrees()),
            currentObject.Direction);

            screenInfo.GraphicSurface.DrawLine(dashedPen, line.PointFrom.X, line.PointFrom.Y, line.PointTo.X, line.PointTo.Y);
        }
    }
}
