namespace DeepSpaceSaga.Common.Universe;

[Serializable]
public class CelestialMap
{
    private List<ICelestialObject> _celestialObjects = new List<ICelestialObject>();

    public CelestialMap(List<ICelestialObject> objects)
    {
        _celestialObjects = objects;
    }

    public List<ICelestialObject> GetCelestialObjects()
    {
        return _celestialObjects;
    }

    public void Add(List<ICelestialObject> celestialObjects)
    {
        foreach (var celestialObject in celestialObjects)
        {
            _celestialObjects.Add(celestialObject);
        }
    }

    public void Add(ICelestialObject celestialObject)
    {
        _celestialObjects.Add(celestialObject);
    }

    public void Clear()
    {
        _celestialObjects = new List<ICelestialObject>();
    }
}
