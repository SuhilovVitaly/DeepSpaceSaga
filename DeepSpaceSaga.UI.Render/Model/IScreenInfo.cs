namespace DeepSpaceSaga.UI.Render.Model;

public interface IScreenInfo
{
    ScreenMetrics Metrics { get; set; }
    PointF Center { get; }
    float Width { get; }
    float Height { get; }
    int DrawInterval { get; set; }
    PointF CenterScreenOnMap { get; set; }
    Zoom Zoom { get; }
    Graphics GraphicSurface { get; set; }
}