namespace DeepSpaceSaga.UI.Render.Tools;

public class DrawTools
{
    public static void DrawString(IScreenInfo screen, string text, Font font, SpaceMapColor color, RectangleF rectangle)
    {
        using var textPaint = new SKPaint
        {
            Color = color.ToSKColor(),
            TextSize = font.Size,
            IsAntialias = true
        };

        screen.GraphicSurface.DrawText(text, new SKPoint(rectangle.X, rectangle.Y), font.ConvertToSKFont(), textPaint);
    }

    public static void DrawEllipse(IScreenInfo screen, float x, float y, float radius, SpaceMapColor color)
    {
        using var gridPaint = new SKPaint
        {
            Color = color.ToSKColor(),
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        screen.GraphicSurface.DrawCircle(x, y, radius, gridPaint);
    }

    public static void FillEllipse(IScreenInfo screen, float x, float y, float radius, SpaceMapColor color)
    {
        using var gridPaint = new SKPaint
        {
            Color = color.ToSKColor(),
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Fill
        };

        screen.GraphicSurface.DrawCircle(x, y, radius, gridPaint);
    }

    public static void DrawLine(IScreenInfo screen, SpaceMapColor color, SpaceMapPoint p1, SpaceMapPoint p2)
    {
        using var gridPaint = new SKPaint
        {
            Color = color.ToSKColor(),
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        screen.GraphicSurface.DrawLine(p1.ToSkPoint(), p2.ToSkPoint(), gridPaint);
    }
}
