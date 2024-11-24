namespace DeepSpaceSaga.Common.Tools;

public class SpaceMapEventHandler(GameSession session)
{
    public event Action<ICelestialObject>? OnShowCelestialObject;
    public event Action<ICelestialObject>? OnSelectCelestialObject;

    private readonly GameSession gameSession = session;

    public void MouseMove(PointF coordinates)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        OnShowCelestialObject?.Invoke(objectsInRange.First());
    }

    public void MouseClick(PointF coordinates)
    {
        var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

        OnSelectCelestialObject?.Invoke(objectsInRange.First());
    }
}

