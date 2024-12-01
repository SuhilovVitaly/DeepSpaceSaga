namespace DeepSpaceSaga.Server.Generation;

internal class CelestialMapGenerator
{
    public static CelestialMap GenerateEmptyBase()
    {
        var generationTool = new GenerationTool();

        var objects = new List<ICelestialObject>
        {
            SpacecraftGenerator.GetPlayerSpacecraft(),
            AsteroidGenerator.CreateAsteroid(217, 10000 - 310, 10000 - 221, 7, generationTool.GenerateCelestialObjectName()),
            AsteroidGenerator.CreateAsteroid(327, 10000 + 10, 10000 + 277, 7, generationTool.GenerateCelestialObjectName(), true)
        };

        return new CelestialMap(objects);
    }
}
