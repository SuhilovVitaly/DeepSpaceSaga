using SkiaSharp;

namespace DeepSpaceSaga.UI.Render.Model;

public class ScreenParameters : IScreenInfo
{
    public ScreenMetrics Metrics { get; set; } = new ScreenMetrics();
    public PointF Center { get; }
    public float Width { get; }
    public float Height { get; }
    public int DrawInterval { get; set; }
    public PointF CenterScreenOnMap { get; set; }
    public SKCanvas GraphicSurface { get; set; }
    public Zoom Zoom { get; }

    public bool IsPlayerSpacecraftCenterScreen { get; set; } = true;

    public ScreenParameters(float width, float height, int centerScreenX = 10000, int centerScreenY = 10000, int zoomSize = 1000)
    {
        Center = new PointF(width / 2, height / 2);

        // Start player ship coordinates in each battle (10000, 10000)
        CenterScreenOnMap = new PointF(centerScreenX, centerScreenY);

        Width = width;
        Height = height;

        Zoom = new Zoom(zoomSize);
    }

    public ScreenParameters(ScreenParameters preset, int zoomSize)
    {
        Center = preset.Center;
        CenterScreenOnMap = preset.CenterScreenOnMap;
        Width = preset.Width;
        Height = preset.Height;
        Zoom = new Zoom(zoomSize);
    }

    public RectangleF VisibleScreen()
    {
        return new RectangleF(CenterScreenOnMap.X - Width / 2,
            CenterScreenOnMap.Y - Height / 2,
            Width, Height);
    }

    public bool PointInVisibleScreen(float x, float y)
    {
        return VisibleScreen().Contains((int)x, (int)y);
    }

    public bool PointInVisibleScreen(PointF point)
    {
        return VisibleScreen().Contains((int)point.X, (int)point.Y);
    }
}

