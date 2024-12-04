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

        for(int i = 0; i < 500; i++)
        {
            var asteroid = AsteroidGenerator.CreateAsteroid(
                generationTool.GetDouble(0, 359),
                generationTool.GetDouble(9000, 11000),
                generationTool.GetDouble(9000, 11000),
                generationTool.GetDouble(1, 10),
                generationTool.GenerateCelestialObjectName()
                , true);

            objects.Add(asteroid);
        }

        return new CelestialMap(objects);
    }
}
