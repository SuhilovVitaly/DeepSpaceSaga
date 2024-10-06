namespace DeepSpaceSaga.UI.Model;

public interface IScreenInfo
{
    ScreenMetrics Metrics { get; set; }
    PointF Center { get; }
    float Width { get; }
    float Height { get; }
    int DrawInterval { get; set; }
    PointF CenterScreenOnMap { get; set; }

    Point ControlActiveCelestialObjectLocation { get; set; }

    int ActiveCelestialObjectId { get; set; }

    Zoom Zoom { get; }
}