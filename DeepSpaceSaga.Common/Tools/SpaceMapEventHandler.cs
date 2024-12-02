﻿namespace DeepSpaceSaga.Common.Tools;

public class SpaceMapEventHandler()
{
    public event Action<ICelestialObject>? OnShowCelestialObject;
    public event Action<ICelestialObject>? OnSelectCelestialObject;

    public void MouseMove(PointF coordinates, GameSession gameSession)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        if (objectsInRange.Count() == 0) return;

        OnShowCelestialObject?.Invoke(objectsInRange.First());
    }

    public void MouseClick(PointF coordinates, GameSession gameSession)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        if (objectsInRange.Count() == 0) return;

        OnSelectCelestialObject?.Invoke(objectsInRange.First());
    }
}

