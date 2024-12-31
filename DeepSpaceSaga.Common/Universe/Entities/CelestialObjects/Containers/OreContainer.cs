namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Containers;

public class OreContainer: BaseCelestialObject, IContainer
{
    public List<ICoreItem> Items { get; set; } = new List<ICoreItem>();
}
