namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        int OwnerId { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        double Speed { get; set; }
        double PositionX { get; set; }
        double PositionY { get; set; }
        CelestialObjectTypes Types { get; set; }
        bool IsPreScanned { get; set; }
        float Size { get; set; }
    }
}
