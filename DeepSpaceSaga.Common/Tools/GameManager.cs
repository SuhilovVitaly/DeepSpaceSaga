namespace DeepSpaceSaga.Common.Tools;

public class GameManager
{
    private GameSession session;
    public SpaceMapEventHandler MapEventHandler { get; init; }

    public GameManager(GameSession gameSession)
    {
        session = gameSession;
        MapEventHandler = new SpaceMapEventHandler(session);
        MapEventHandler.OnShowCelestialObject += MapEventHandler_OnShowCelestialObject;
        MapEventHandler.OnSelectCelestialObject += MapEventHandler_OnSelectCelestialObject;
    }

    private void MapEventHandler_OnSelectCelestialObject(ICelestialObject obj)
    {
        
    }

    private void MapEventHandler_OnShowCelestialObject(ICelestialObject obj)
    {
        
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
