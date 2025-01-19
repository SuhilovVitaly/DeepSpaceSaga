namespace DeepSpaceSaga.Common.Tools;

public class SpaceMapEventHandler()
{
    public event Action<ICelestialObject>? OnHideCelestialObject;
    public event Action<ICelestialObject>? OnShowCelestialObject;
    public event Action<ICelestialObject>? OnSelectCelestialObject;

    public void MouseMove(SpaceMapPoint coordinates, GameSessionDTO gameSession)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        if (objectsInRange.Count() == 0)
        {
            OnHideCelestialObject?.Invoke(gameSession.GetPlayerSpaceShip());
            return;
        }

        OnShowCelestialObject?.Invoke(objectsInRange.First());
    }

    public void MouseClick(SpaceMapPoint coordinates, GameSessionDTO gameSession)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        if (objectsInRange.Count() == 0) return;

        OnSelectCelestialObject?.Invoke(objectsInRange.First());
    }
}

