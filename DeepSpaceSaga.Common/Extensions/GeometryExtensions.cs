﻿namespace DeepSpaceSaga.Common.Extensions;

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

    public static Vector2 ToVector2(this PointF point)
    {
        return new Vector2(point.X, point.Y);
    }

    public static Vector2 ToVector2(this Point point)
    {
        return new Vector2(point.X, point.Y);
    }

    public static Point ToPoint(this Vector2 point)
    {
        return new Point((int)point.X, (int)point.Y);
    }

    public static PointF ToPointF(this Vector2 point)
    {
        return new PointF(point.X, point.Y);
    }

    public static PointF ToPointF(this Point point)
    {
        return new PointF(point.X, point.Y);
    }
}