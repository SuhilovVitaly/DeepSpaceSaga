namespace DeepSpaceSaga.Common.Universe;

[Serializable]
public class CelestialMap(IEnumerable<ICelestialObject> objects) : List<ICelestialObject>(objects)
{
    public List<ICelestialObject> GetCelestialObjects()
    {
        return this.ToList(); ;
    }    

    public void AddCelestialObjects(List<ICelestialObject> celestialObjects)
    {
        AddRange(celestialObjects);
    }
    
    public void ClearMap()
    {
        Clear();
    }
}

