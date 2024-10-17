namespace WinFormsApp1;

internal class CelestialObject
{
    public CelestialObjectType Type { get; set; }

    public CelestialObject Barycenter;
    public PointF PerigeePosition { get; set; }
    public PointF ApogeePosition { get; set; }
    public float OrbitAngle { get; set; }
    public double Angle { get; set; }
    public double Speed { get; set; }
    public int Radius { get; set; }
    public float Apogee { get; set; }
    public float Perigee { get; set; }
    public Color Color { get; set; }

    public Color OrbitColor { get; set; } = ColorTranslator.FromHtml("#314c5d");

    public float Eccentricity { get; set; }

    public float SemiMajorAxis { get; set; }

    public float SemiMinorAxis { get; set; }

    public float FocalDistance { get; set; }

    public PointF CenterOfOrbit { get; set; }

    public ObjectLocation Location { get; set; }

    public string Name { get; set; }

    internal void UpdateLocation()
    {
        if (Type == CelestialObjectType.Sun) return;
        // Угол наклона орбиты в радианах
        float orbitAngleRadians = (float)(OrbitAngle * Math.PI / 180);

        // Центр орбиты относительно Солнца (учитываем смещение фокуса)
        float centerX = Barycenter.Location.X + FocalDistance * (float)Math.Cos(orbitAngleRadians);
        float centerY = Barycenter.Location.Y + FocalDistance * (float)Math.Sin(orbitAngleRadians);
        PointF centerOfOrbit = new PointF(centerX, centerY);

        // Вычисляем положение планеты на эллиптической орбите относительно центра орбиты
        float x = (float)(SemiMajorAxis * Math.Cos(Angle));  // Положение по X (большая полуось)
        float y = (float)(SemiMinorAxis * Math.Sin(Angle));  // Положение по Y (малая полуось)

        // Применяем поворот на угол наклона орбиты
        float rotatedX = (float)(x * Math.Cos(orbitAngleRadians) - y * Math.Sin(orbitAngleRadians));
        float rotatedY = (float)(x * Math.Sin(orbitAngleRadians) + y * Math.Cos(orbitAngleRadians));

        // Сдвигаем планету относительно центра орбиты (фокус находится в позиции Солнца)
        Location = new ObjectLocation(centerOfOrbit.X + rotatedX, centerOfOrbit.Y + rotatedY);
    }

    internal void UpdateAngle()
    {
        if (Type == CelestialObjectType.Sun) return;

        // Вычисляем текущее расстояние планеты до Солнца
        float distanceToSun = (float)Math.Sqrt(
            Math.Pow(Location.X - Barycenter.Location.X, 2) +
            Math.Pow(Location.Y - Barycenter.Location.Y, 2));

        // Пропорционально изменяем скорость планеты в зависимости от расстояния до Солнца
        // Чем ближе планета к Солнцу, тем быстрее она движется
        float speedFactor = SemiMajorAxis / (22 * distanceToSun);  // Пример обратнопропорциональной зависимости

        if (Type == CelestialObjectType.Planet)
        {
            Angle += Speed * speedFactor;
        }
        else
        {
            Angle += Speed;
        }

        // Убедимся, что угол находится в пределах от 0 до 2π (360 градусов)
        if (Angle >= 2 * Math.PI)
        {
            Angle -= 2 * Math.PI;
        }
    }

    internal void Initialization()
    {
        // Рассчитываем эксцентриситет орбиты
        Eccentricity = (Apogee - Perigee) / (Apogee + Perigee);

        // Рассчитываем большую полуось (semiMajorAxis)
        SemiMajorAxis = (Apogee + Perigee) / 2;

        // Рассчитываем малую полуось (semiMinorAxis)
        SemiMinorAxis = SemiMajorAxis * (float)Math.Sqrt(1 - Eccentricity * Eccentricity);

        // Фокусное расстояние — расстояние от центра орбиты до Солнца
        FocalDistance = SemiMajorAxis * Eccentricity;

        // Позиция центра орбиты относительно Солнца (учитываем фокусное смещение)
        CenterOfOrbit = new PointF(Barycenter.Location.X + FocalDistance, Barycenter.Location.Y);

        // Вычисляем перигей и апогей
        PointF perigee = new PointF(FocalDistance - SemiMajorAxis, 0); // Перигей ближе к Солнцу
        PointF apogee = new PointF(FocalDistance + SemiMajorAxis, 0);  // Апогей дальше от Солнца

        // Угол наклона орбиты в радианах
        float orbitAngleRadians = (float)(OrbitAngle * Math.PI / 180);

        // Применяем угол наклона орбиты к перигею и апогею
        PerigeePosition = RotatePoint(perigee.X, perigee.Y, orbitAngleRadians);
        ApogeePosition = RotatePoint(apogee.X, apogee.Y, orbitAngleRadians);

        // Смещаем перигей и апогей относительно Солнца
        PerigeePosition = new PointF(Barycenter.Location.X + PerigeePosition.X, Barycenter.Location.Y + PerigeePosition.Y);
        ApogeePosition = new PointF(Barycenter.Location.X + ApogeePosition.X, Barycenter.Location.Y + ApogeePosition.Y);

        UpdateAngle();
        UpdateLocation();
    }

    private PointF RotatePoint(float x, float y, double angle)
    {
        float rotatedX = (float)(x * Math.Cos(angle) - y * Math.Sin(angle));
        float rotatedY = (float)(x * Math.Sin(angle) + y * Math.Cos(angle));
        return new PointF(rotatedX, rotatedY);
    }
}
