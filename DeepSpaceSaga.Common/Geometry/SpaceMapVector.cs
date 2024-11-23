namespace DeepSpaceSaga.Common.Geometry;

public class SpaceMapVector
{
    public PointF PointFrom { get; set; }
    public PointF PointTo { get; set; }
    public double Direction { get; set; }

    public SpaceMapVector(PointF pointFrom, PointF pointTo, double direction)
    {
        PointFrom = pointFrom;
        PointTo = pointTo;
        Direction = direction;
    }
}
