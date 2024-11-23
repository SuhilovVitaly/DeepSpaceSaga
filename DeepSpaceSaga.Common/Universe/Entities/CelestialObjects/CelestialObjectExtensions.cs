namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects
{
    public static class CelestialObjectExtensions
    {
        public static PointF Location(this ICelestialObject celestialObject)
        {
            return new PointF((float)celestialObject.PositionX, (float)celestialObject.PositionY);
        }
    }
}
