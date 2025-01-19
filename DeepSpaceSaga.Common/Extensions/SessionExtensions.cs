using System.Linq;

namespace DeepSpaceSaga.Common.Extensions;

public static class SessionExtensions
{
    public static ISpacecraft GetPlayerSpaceShip(CelestialMap? spaceMap)
    {
        foreach (var celestialObject in from celestialObject in spaceMap?.GetCelestialObjects()
                                        where celestialObject.Types == CelestialObjectTypes.SpaceshipPlayer
                                        select celestialObject)
        {
            return celestialObject.ToSpaceship();
        }

        throw new InvalidOperationException("Player spaceship not found in the game session");
    }

    public static ISpacecraft GetPlayerSpaceShip(this GameSessionDTO session)
    {
        return GetPlayerSpaceShip(session.SpaceMap);
    }

    public static ISpacecraft GetPlayerSpaceShip(this GameSession session)
    {
        return GetPlayerSpaceShip(session.SpaceMap);
    }

    public static ICelestialObject GetCelestialObject(this GameSessionDTO gameSession, long id, bool isCopy = false)
    {
        var celestialObjects = gameSession.SpaceMap.GetCelestialObjects();
        var celestialObject = celestialObjects.FirstOrDefault(x => x.Id == id);
        
        return isCopy ? celestialObject?.Copy() : celestialObject;
    }

    public static List<ICelestialObject> GetCelestialObjectsByDistance(this GameSessionDTO gameSession, SpaceMapPoint coordinates, int range)
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
