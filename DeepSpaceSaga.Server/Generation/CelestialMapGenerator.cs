namespace DeepSpaceSaga.Server.Generation;

internal class CelestialMapGenerator
{
    public static CelestialMap GenerateEmptyBase()
    {
        var objects = new List<ICelestialObject>
        {
            SpacecraftGenerator.GetPlayerSpacecraft(),
            AsteroidGenerator.CreateAsteroid(217, 10000 - 310, 10000 - 221, 7, "ASR-CS-212"),
            AsteroidGenerator.CreateAsteroid(327, 10000 + 10, 10000 + 277, 7, "ASR-CS-531")
        };

        return new CelestialMap(objects);
    }
}
