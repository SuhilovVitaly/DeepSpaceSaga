namespace DeepSpaceSaga.Common.Universe;

public class CelestialMap(IEnumerable<ICelestialObject> objects) : List<ICelestialObject>(objects)
{
    public List<ICelestialObject> GetCelestialObjects()
    {
        return this.ToList(); ;
    }

    public void AddCelestialObjects(List<ICelestialObject> celestialObjects)
    {
        foreach (var celestialObject in celestialObjects)
        {
            Add(celestialObject);
        }
    }
    
    public void ClearMap()
    {
        Clear();
    }
}

