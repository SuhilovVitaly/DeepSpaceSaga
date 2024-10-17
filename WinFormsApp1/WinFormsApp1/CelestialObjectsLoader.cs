using OutlandSpace.Universe.Tools;

namespace WinFormsApp1;

internal class CelestialObjectsLoader
{
    public static List<CelestialObject> GetCelestialObjects()
    {
        var celestialObjects = new List<CelestialObject>();

        var random = new GenerationTool();

        var sun = new CelestialObject
        {
            Radius = 12,
            Location = new ObjectLocation(800, 600),
            Type = CelestialObjectType.Sun,
            Color = ColorTranslator.FromHtml("#f0de12"),
            Name = "Солнце"
        };

        celestialObjects.Add(sun);

        var planet = new CelestialObject
        {
            Barycenter = sun,
            Radius = 4,
            Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
            Speed = 0.02, // Стартовая базовая скорость планеты
            OrbitAngle = 180, // Угол наклона орбиты
            Location = new ObjectLocation(0, 0),
            Apogee = 500f,
            Perigee = 490f,
            Type = CelestialObjectType.Planet,
            Name = "Марс",
            Color = Color.DarkOrange,
            OrbitColor = Color.WhiteSmoke,
        };

        planet.Initialization();

        celestialObjects.Add(planet);

        var mercury = new CelestialObject
        {
            Barycenter = sun,
            Radius = 4,
            Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
            Speed = 0.02, // Стартовая базовая скорость планеты
            OrbitAngle = 180, // Угол наклона орбиты
            Location = new ObjectLocation(0, 0),
            Apogee = 140f,
            Perigee = 140f,
            Type = CelestialObjectType.Planet,
            Name = "Меркурий",
            Color = Color.DarkViolet,
            OrbitColor = Color.WhiteSmoke,
        };

        mercury.Initialization();

        celestialObjects.Add(mercury);

        var earth = new CelestialObject
        {
            Barycenter = sun,
            Radius = 6,
            Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
            Speed = 0.02, // Стартовая базовая скорость планеты
            OrbitAngle = 180, // Угол наклона орбиты
            Location = new ObjectLocation(0, 0),
            Apogee = 380f,
            Perigee = 370f,
            Type = CelestialObjectType.Planet,
            Name = "Земля",
            Color = Color.DarkOliveGreen,
            OrbitColor = Color.WhiteSmoke,
        };

        earth.Initialization();

        celestialObjects.Add(earth);

        var venus = new CelestialObject
        {
            Barycenter = sun,
            Radius = 6,
            Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
            Speed = 0.02, // Стартовая базовая скорость планеты
            OrbitAngle = 180, // Угол наклона орбиты
            Location = new ObjectLocation(0, 0),
            Apogee = 250f,
            Perigee = 250f,
            Type = CelestialObjectType.Planet,
            Name = "Венера",
            Color = Color.Olive,
            OrbitColor = Color.WhiteSmoke,
        };

        venus.Initialization();

        celestialObjects.Add(venus);

        var didymos = new CelestialObject
        {
            Barycenter = sun,
            Radius = 4,
            Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
            Speed = 0.02, // Стартовая базовая скорость планеты
            OrbitAngle = 45, // Угол наклона орбиты
            Location = new ObjectLocation(0, 0),
            Apogee = 750f,
            Perigee = 350f,
            Type = CelestialObjectType.Planet,
            Name = "Дидим",
            Color = Color.Wheat,
            OrbitColor = ColorTranslator.FromHtml("#72bfdd"),
        }; 

        didymos.Initialization();

        celestialObjects.Add(didymos);

        // Инициализация Луны
        var moon = new CelestialObject
        {
            Barycenter = planet,
            Radius = 2,  // Радиус Луны меньше радиуса планеты
            Angle = 0.0, // Начальный угол для орбиты Луны
            Speed = 0.05, // Скорость Луны может быть выше, чтобы она быстрее вращалась
            OrbitAngle = 0, // У Луны круговая орбита вокруг планеты
            Location = new ObjectLocation(0, 0), // Положение будет вычисляться динамически
            Apogee = 15f, // Орбита Луны фиксирована в 50 пикселей
            Perigee = 15f, // Тоже фиксирована
            Type = CelestialObjectType.Moon,
            Name = "Фобос"
        };

        moon.Initialization();  // Луна вращается вокруг планеты

        //celestialObjects.Add(moon);

        // Инициализация Луны
        var moonSecond = new CelestialObject
        {
            Barycenter = planet,
            Radius = 2,  // Радиус Луны меньше радиуса планеты
            Angle = 0.0, // Начальный угол для орбиты Луны
            Speed = 0.02, // Скорость Луны может быть выше, чтобы она быстрее вращалась
            OrbitAngle = 0, // У Луны круговая орбита вокруг планеты
            Location = new ObjectLocation(0, 0), // Положение будет вычисляться динамически
            Apogee = 35f, // Орбита Луны фиксирована в 50 пикселей
            Perigee = 35f, // Тоже фиксирована
            Type = CelestialObjectType.Moon,
            Name = "Деймос"
        };

        moonSecond.Initialization();  // Луна вращается вокруг планеты

        //celestialObjects.Add(moonSecond);

        for (int i = 0; i < 520; i++)
        {
            var asteroid = new CelestialObject
            {
                Barycenter = sun,
                Radius = 1,
                Angle = random.GetInteger(0, 359) * (180.0 / Math.PI), // Начальный угол для орбиты(в радианах)
                Speed = 0.0002, // Стартовая базовая скорость планеты
                OrbitAngle = random.GetInteger(0, 359), // Угол наклона орбиты
                Location = new ObjectLocation(0, 0),
                Apogee = random.GetFloat(1500, 500),
                Perigee = random.GetFloat(500, 70),
                Type = CelestialObjectType.Asteroid,
                Name = "G" + i,
                OrbitColor = ColorTranslator.FromHtml("#314c5d"),
                Color = Color.WhiteSmoke
            };

            asteroid.Initialization();

            celestialObjects.Add(asteroid);
        }

        return celestialObjects;
    }
}
