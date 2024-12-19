namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingLocationsHandler : BaseHandler, ICalculationHandler
{
    public int Order => 2;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (var celestialObject in context.Session.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(celestialObject);
        }

        return context;
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
