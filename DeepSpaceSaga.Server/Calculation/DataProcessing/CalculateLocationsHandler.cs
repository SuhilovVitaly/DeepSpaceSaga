namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class CalculateLocationsHandler
{
    public static GameSession Execute(GameSession session)
    {
        return new CalculateLocationsHandler().Run(session);
    }

    internal GameSession Run(GameSession session)
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
