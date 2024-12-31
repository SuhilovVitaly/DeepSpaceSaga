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

        throw new InvalidOperationException("Player spaceship not found in the game session");
    }

    public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id, bool isCopy = false)
    {
        var celestialObjects = gameSession.SpaceMap.GetCelestialObjects();
        var celestialObject = celestialObjects.FirstOrDefault(x => x.Id == id);
        
        return isCopy ? celestialObject?.Copy() : celestialObject;
    }

    public static List<ICelestialObject> GetCelestialObjectsByDistance(this GameSession gameSession, SpaceMapPoint coordinates, int range)
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

    public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id)
    {
        return gameSession.SpaceMap?.FirstOrDefault(x => x.Id == id);
    }
}
