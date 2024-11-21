﻿namespace DeepSpaceSaga.UI.Render.Tools;

public class UiTools
{
    public static PointF ToScreenCoordinates(IScreenInfo screenParameters, PointF celestialObjectPosition)
    {
        var relativeX = celestialObjectPosition.X - screenParameters.CenterScreenOnMap.X + screenParameters.Width / 2;
        var relativeY = celestialObjectPosition.Y - screenParameters.CenterScreenOnMap.Y + screenParameters.Height / 2;

        return new PointF(relativeX, relativeY);
    }


    internal static PointF ToScreenCoordinates(IScreenInfo screenInfo, double positionX, double positionY)
    {
        return ToScreenCoordinates(screenInfo, new PointF((float)positionX, (float)positionY));
    }

    internal static int ZoomToCellSize(int zoomSize)
    {
        return zoomSize switch
        {
            1 => 50,
            2 => 25,
            _ => throw new ArgumentException(),
        };
    }
}