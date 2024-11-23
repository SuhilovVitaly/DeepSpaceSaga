namespace DeepSpaceSaga.Common.Tools;

public class GameManager
{
    private GameSession session;

    public GameManager(GameSession gameSession)
    {
        session = gameSession;
    }

    public ISpacecraft GetPlayerSpacecraft()
    {
        return session.SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.OwnerId == 1) as ISpacecraft;
    }

    public CelestialMap GetCelestialMap()
    {
        return  session.SpaceMap;
    }

    public GameSession GetSession()
    {
        return session;
    }
}
