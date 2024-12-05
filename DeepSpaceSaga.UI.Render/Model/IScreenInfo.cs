namespace DeepSpaceSaga.UI.Render.Model;

public interface IScreenInfo
{
    ScreenMetrics Metrics { get; set; }
    SpaceMapPoint Center { get; }
    float Width { get; }
    float Height { get; }
    int DrawInterval { get; set; }
    SpaceMapPoint CenterScreenOnMap { get; set; }
    Zoom Zoom { get; }
    SKCanvas GraphicSurface { get; set; }
}