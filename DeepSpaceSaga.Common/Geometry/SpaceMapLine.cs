namespace DeepSpaceSaga.Common.Geometry;

public class SpaceMapLine
{
    public PointF From { get; set; }

    public PointF To { get; set; }

    public SpaceMapLine(PointF from, PointF to)
    {
        From = from;
        To = to;
    }
}
