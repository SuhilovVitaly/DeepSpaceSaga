namespace DeepSpaceSaga.Common.Extensions;

public static class SessionExtensions
{
    public static ISpacecraft GetPlayerSpaceShip(this GameSession session)
    {
        foreach (var celestialObject in session.SpaceMap.GetCelestialObjects())
        {
            if (celestialObject.Types == CelestialObjectTypes.SpaceshipPlayer)
            {
                return celestialObject.ToSpaceship();
            }
        }

        return null;
    }

    public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id, bool isCopy = false)
    {
        if (isCopy)
            return (from celestialObjects in gameSession.SpaceMap.GetCelestialObjects() where id == celestialObjects.Id select celestialObjects.Copy()).FirstOrDefault();

        return (from celestialObjects in gameSession.SpaceMap.GetCelestialObjects() where id == celestialObjects.Id select celestialObjects).FirstOrDefault();
    }

    public static List<ICelestialObject> GetCelestialObjectsByDistance(this GameSession gameSession, PointF coordinates, int range)
    {
        var resultObjects = gameSession.SpaceMap.GetCelestialObjects().Map(celestialObject => (celestialObject,
                    GeometryTools.Distance(
                        coordinates,
                        celestialObject.GetLocation())
                )).
            Where(e => e.Item2 < range).
            OrderBy(e => e.Item2).
            Map(e => e.celestialObject).
            ToList();

        return resultObjects;
    }
}
