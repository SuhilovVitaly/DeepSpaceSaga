namespace DeepSpaceSaga.Server.Generation;

internal class CelestialMapGenerator
{
    public static CelestialMap GenerateEmptyBase()
    {
        var objects = new List<ICelestialObject>
        {
            SpacecraftGenerator.GetPlayerSpacecraft()
        };

        return new CelestialMap(objects);
    }
}
