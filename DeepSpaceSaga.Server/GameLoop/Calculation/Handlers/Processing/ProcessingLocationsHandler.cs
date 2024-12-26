namespace DeepSpaceSaga.Server.GameLoop.Calculation.Handlers.Processing;

public class ProcessingLocationsHandler : BaseHandler, ICalculationHandler
{
    public int Order => 2;

    public HandlerType Type => HandlerType.Processing;

    public SessionContext Handle(SessionContext context)
    {
        foreach (var celestialObject in context.Session.SpaceMap.GetCelestialObjects())
        {
            RecalculateOneTickObjectLocation(context, celestialObject);
        }

        return context;
    }

    private void RecalculateOneTickObjectLocation(SessionContext context, ICelestialObject celestialObject)
    {
        double tickSpeed = celestialObject.Speed / ( 1000 / context.Settings.TickInterval);

        var position = GeometryTools.Move(
            celestialObject.GetLocation(),
            tickSpeed,
            celestialObject.Direction);

        celestialObject.PositionX = position.X;
        celestialObject.PositionY = position.Y;
    }
}
