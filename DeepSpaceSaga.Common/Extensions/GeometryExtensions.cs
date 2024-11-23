namespace DeepSpaceSaga.Common.Extensions;

public static class GeometryExtensions
{
    public static float To360Degrees(this float angle)
    {
        if (angle > 360) angle = angle - 360;
        if (angle < 0) angle = 360 + angle;

        return angle;
    }

    public static double To360Degrees(this double angle)
    {
        if (angle > 360) angle = angle - 360;
        if (angle < 0) angle = 360 + angle;

        return angle;
    }
}
