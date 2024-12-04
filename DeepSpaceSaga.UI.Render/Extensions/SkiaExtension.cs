using LanguageExt;

namespace DeepSpaceSaga.UI.Render.Extensions;

public static class SkiaExtension
{
    public static void FillEllipse(this SKCanvas canvas, SolidBrush solidBrush, float x, float y, float width, float hight)
    {
        var smallGridPen = new SKColor(solidBrush.Color.R, solidBrush.Color.G, solidBrush.Color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Fill
        };

        canvas.DrawCircle(x, y, width * 2, gridPaint);
    }

    public static void DrawEllipse(this SKCanvas canvas, Pen pen, float x, float y, float width, float hight)
    {
        var smallGridPen = new SKColor(pen.Color.R, pen.Color.G, pen.Color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        canvas.DrawCircle(x, y, width * 2, gridPaint);
    }

    public static void FillRectangle(this SKCanvas canvas, SolidBrush solidBrush, float x, float y, float width, float hight)
    {
        var smallGridPen = new SKColor(solidBrush.Color.R, solidBrush.Color.G, solidBrush.Color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Fill
        };

        canvas.DrawRect(x, y, width, hight, gridPaint);
    }

    public static void DrawLine(this SKCanvas canvas, Pen pen, PointF p1, PointF p2)
    {
        var smallGridPen = new SKColor(pen.Color.R, pen.Color.G, pen.Color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        canvas.DrawLine(p1.ToSkPoint(), p2.ToSkPoint(), gridPaint);
    }

    public static void DrawLine(this SKCanvas canvas, Pen pen, float p1x, float p1y, float p2x, float p2y)
    {
        var smallGridPen = new SKColor(pen.Color.R, pen.Color.G, pen.Color.B);

        using var gridPaint = new SKPaint
        {
            Color = smallGridPen,
            StrokeWidth = 1,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        canvas.DrawLine(new SKPoint(p1x, p1y), new SKPoint(p2x, p2y), gridPaint);
    }

    public static SKPoint ToSkPoint(this PointF point)
    {
        return new SKPoint(point.X, point.Y);
    }

    public static void DrawString(this SKCanvas canvas, string text, Font font, SolidBrush solidBrush, RectangleF rectangle)
    {
        var smallGridPen = new SKColor(solidBrush.Color.R, solidBrush.Color.G, solidBrush.Color.B);

        using var textPaint = new SKPaint
        {
            Color = SKColors.White,
            TextSize = font.Size,
            IsAntialias = true
        };

        canvas.DrawText(text, new SKPoint(rectangle.X, rectangle.Y), ConvertToSKFont(font), textPaint);
    }

    public static SKFont ConvertToSKFont(Font font)
    {
        if (font == null)
        {
            throw new ArgumentNullException(nameof(font), "Font cannot be null.");
        }

        // Создаем SKTypeface на основе имени шрифта
        SKTypeface typeface = SKTypeface.FromFamilyName(font.FontFamily.Name,
            font.Bold ? SKFontStyleWeight.Bold : SKFontStyleWeight.Normal,
            font.Italic ? SKFontStyleWidth.Condensed : SKFontStyleWidth.Normal,
            SKFontStyleSlant.Upright);

        // Создаем SKFont с указанным размером
        var skFont = new SKFont(typeface, font.Size);

        return skFont;
    }
}
