namespace DeepSpaceSaga.UI.Render.Model;

public class ScreenParameters : IScreenInfo
{
    public ScreenMetrics Metrics { get; set; } = new ScreenMetrics();
    public SpaceMapPoint Center { get; }
    public float Width { get; }
    public float Height { get; }
    public int DrawInterval { get; set; }
    public SpaceMapPoint CenterScreenOnMap { get; set; }
    public SKCanvas GraphicSurface { get; set; }
    public Zoom Zoom { get; }

    public bool IsPlayerSpacecraftCenterScreen { get; set; } = true;

    public ScreenParameters(float width, float height, int centerScreenX = 10000, int centerScreenY = 10000, int zoomSize = 1000)
    {
        Center = new SpaceMapPoint(width / 2, height / 2);

        // Start player ship coordinates in each battle (10000, 10000)
        CenterScreenOnMap = new SpaceMapPoint(centerScreenX, centerScreenY);

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
}

