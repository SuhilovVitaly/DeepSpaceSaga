namespace DeepSpaceSaga.Common.Universe.Entities.CelestialObjects.Containers;

public interface IContainer: ICelestialObject
{
    List<ICoreItem> Items { get; set; }
}
