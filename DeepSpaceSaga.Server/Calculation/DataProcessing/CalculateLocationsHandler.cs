namespace DeepSpaceSaga.Server.Calculation.DataProcessing;

internal class CalculateLocationsHandler
{
    public static SessionContext Execute(SessionContext sessionContext)
    {
        return new CalculateLocationsHandler().Run(sessionContext);
    }

    internal SessionContext Run(SessionContext sessionContext)
    {
        foreach (var celestialObject in sessionContext.Session.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(celestialObject);
        }

        return sessionContext;
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
