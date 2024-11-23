namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class Coordinates
{
    public GameSession Recalculate(GameSession session)
    {
        foreach (var celestialObject in session.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(celestialObject);
        }

        return session.Copy();
    }

    private void RecalculateOneTickObjectLocation(ICelestialObject celestialObject)
    {
        var tickSpeed = celestialObject.Speed / 10;

        var position = GeometryTools.Move(
            celestialObject.GetLocation(),
            tickSpeed,
            celestialObject.Direction);

        celestialObject.PositionX = position.X;
        celestialObject.PositionY = position.Y;
    }
}
