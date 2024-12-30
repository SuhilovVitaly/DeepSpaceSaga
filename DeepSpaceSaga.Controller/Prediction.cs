namespace DeepSpaceSaga.Controller;

public class Prediction
{
    public static GameSession NextTickLocations(GameSession session)
    {
        var updatedSession = session.Copy();

        foreach(var celestialObject in updatedSession.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(updatedSession, celestialObject);
        }

        return updatedSession;
    }


    private static void RecalculateOneTickObjectLocation(GameSession session, ICelestialObject celestialObject)
    {
        double tickSpeed = celestialObject.Speed / (1000 / 50);

        var position = GeometryTools.Move(
            celestialObject.GetLocation(),
            tickSpeed,
            celestialObject.Direction);

        celestialObject.PositionX = position.X;
        celestialObject.PositionY = position.Y;
    }
}
