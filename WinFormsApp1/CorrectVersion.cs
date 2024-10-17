using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class SolarSystemForm : Form
    {
        private Timer gameTimer;

        private const int crossSize = 10; // Размер перекрестий
        private const int pointSize = 5;  // Размер точек в апогее и перигее

        private Color orbitColor = ColorTranslator.FromHtml("#314c5d");
        private Color colorSun = ColorTranslator.FromHtml("#f0de12");

        private CelestialObject Sun;
        private CelestialObject Planet;

        public SolarSystemForm()
        {
            InitializeComponent();
            InitSolarSystemObjects();
            InitSolarSystem();
        }

        private void InitSolarSystemObjects()
        {
            Sun = new CelestialObject
            {
                Radius = 25,
                Location = new ObjectLocation(800, 600),
            };

            Planet = new CelestialObject
            {
                Radius = 4,
                Angle = 0.0, // Начальный угол для орбиты(в радианах)
                Speed = 0.02, // Стартовая базовая скорость планеты
                OrbitAngle = 145, // Угол наклона орбиты
                Location = new ObjectLocation(0, 0),
                Apogee = 500f,
                Perigee = 100f,
            };

            Planet.Initialization(Sun);
        }

        private void InitSolarSystem()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;


            // Настройка таймера
            gameTimer = new Timer
            {
                Interval = 16 // ~60 FPS
            };

            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        // Игровой цикл
        private void GameLoop(object sender, EventArgs e)
        {
            // Перерисовываем объекты
            Invalidate();
        }

        // Отрисовка планеты, Солнца, орбиты, апогея и перигея
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;


            // Рисуем точки в апогее и перигее
            g.FillEllipse(Brushes.White, Planet.ApogeePosition.X - pointSize / 2, Planet.ApogeePosition.Y - pointSize / 2, pointSize, pointSize);
            g.FillEllipse(Brushes.White, Planet.PerigeePosition.X - pointSize / 2, Planet.PerigeePosition.Y - pointSize / 2, pointSize, pointSize);

            // Рисуем Солнце в одной из фокусных точек эллипса
            g.FillEllipse(new SolidBrush(colorSun), Sun.Location.X - Sun.Radius, Sun.Location.Y - Sun.Radius, 2 * Sun.Radius, 2 * Sun.Radius);


            DrawOrbit(g, Planet, Sun);

            UpdateTailPosition(g, 12);

            // Рисуем планету
            DrawPlanet(g, Planet, Sun);


            // Рисуем перекрестия в апогее и перигее
            DrawCross(g, Planet.ApogeePosition);
            DrawCross(g, Planet.PerigeePosition);
            DrawCross(g, Sun.Location.ToPoint());

            // Рисуем координаты
            DrawCoordinates(g, "Sun", Sun.Location.X, Sun.Location.Y, Sun.Location.ToPoint());
            DrawCoordinates(g, "Planet", Planet.Location.X, Planet.Location.Y, Planet.Location.ToPoint());
            DrawCoordinates(g, "Perigee", Planet.PerigeePosition.X, Planet.PerigeePosition.Y, Planet.PerigeePosition);
            DrawCoordinates(g, "Apogee", Planet.ApogeePosition.X, Planet.ApogeePosition.Y, Planet.ApogeePosition);
        }

        private void DrawOrbit(Graphics g, CelestialObject planet, CelestialObject sun)
        {
            // Прямоугольник, ограничивающий эллипс орбиты
            RectangleF orbitRect = new RectangleF(
                planet.CenterOfOrbit.X - planet.SemiMajorAxis,
                planet.CenterOfOrbit.Y - planet.SemiMinorAxis,
                2 * planet.SemiMajorAxis,
                2 * planet.SemiMinorAxis
            );

            // Угол наклона орбиты в радианах
            float orbitAngleRadians = (float)(planet.OrbitAngle * Math.PI / 180);

            // Создаем матрицу для вращения орбиты на угол наклона (OrbitAngle)
            using (Matrix matrix = new Matrix())
            {
                // Вращаем орбиту на угол наклона относительно центра орбиты
                matrix.RotateAt(planet.OrbitAngle, sun.Location.ToPoint());
                g.Transform = matrix;

                // Рисуем эллипс орбиты
                g.DrawEllipse(new Pen(orbitColor), orbitRect);

                // Сбрасываем трансформацию графики
                g.ResetTransform();
            }

            // Обновляем позиции перигея и апогея
            UpdatePerigeeAndApogeePositions(planet, planet.SemiMajorAxis, Planet.Eccentricity, planet.FocalDistance, sun.Location.ToPoint(), orbitAngleRadians);
        }

        private void DrawPlanet(Graphics g, CelestialObject planet, CelestialObject sun)
        {
            // Угол наклона орбиты в радианах
            float orbitAngleRadians = (float)(planet.OrbitAngle * Math.PI / 180);

            // Центр орбиты относительно Солнца (учитываем смещение фокуса)
            float centerX = sun.Location.X + planet.FocalDistance * (float)Math.Cos(orbitAngleRadians);
            float centerY = sun.Location.Y + planet.FocalDistance * (float)Math.Sin(orbitAngleRadians);
            PointF centerOfOrbit = new PointF(centerX, centerY);

            // Вычисляем положение планеты на эллиптической орбите относительно центра орбиты
            float x = (float)(planet.SemiMajorAxis * Math.Cos(planet.Angle));  // Положение по X (большая полуось)
            float y = (float)(planet.SemiMinorAxis * Math.Sin(planet.Angle));  // Положение по Y (малая полуось)

            // Применяем поворот на угол наклона орбиты
            float rotatedX = (float)(x * Math.Cos(orbitAngleRadians) - y * Math.Sin(orbitAngleRadians));
            float rotatedY = (float)(x * Math.Sin(orbitAngleRadians) + y * Math.Cos(orbitAngleRadians));

            // Сдвигаем планету относительно центра орбиты (фокус находится в позиции Солнца)
            planet.Location = new ObjectLocation(centerOfOrbit.X + rotatedX, centerOfOrbit.Y + rotatedY);

            // Рисуем планету
            g.FillEllipse(Brushes.Blue, planet.Location.X - planet.Radius, planet.Location.Y - planet.Radius, 2 * planet.Radius, 2 * planet.Radius);

            // Обновляем угол для движения планеты
            UpdatePlanetAngle(planet);
        }


        private void UpdatePlanetAngle(CelestialObject planet)
        {
            // Увеличиваем угол движения планеты (при каждом кадре)
            planet.Angle += planet.Speed;

            // Убедимся, что угол находится в пределах от 0 до 2π (360 градусов)
            if (planet.Angle >= 2 * Math.PI)
            {
                planet.Angle -= 2 * Math.PI;
            }
        }



        private void UpdatePerigeeAndApogeePositions(CelestialObject planet, float semiMajorAxis, float eccentricity, float focalDistance, PointF sunLocation, float orbitAngleRadians)
        {
            // Вычисляем перигей и апогей
            PointF perigee = new PointF(focalDistance - semiMajorAxis, 0); // Перигей ближе к Солнцу
            PointF apogee = new PointF(focalDistance + semiMajorAxis, 0);  // Апогей дальше от Солнца

            // Применяем угол наклона орбиты к перигею и апогею
            planet.PerigeePosition = RotatePoint(perigee.X, perigee.Y, orbitAngleRadians);
            planet.ApogeePosition = RotatePoint(apogee.X, apogee.Y, orbitAngleRadians);

            // Смещаем перигей и апогей относительно Солнца
            planet.PerigeePosition = new PointF(sunLocation.X + planet.PerigeePosition.X, sunLocation.Y + planet.PerigeePosition.Y);
            planet.ApogeePosition = new PointF(sunLocation.X + planet.ApogeePosition.X, sunLocation.Y + planet.ApogeePosition.Y);
        }




        private PointF RotatePoint(float x, float y, double angle)
        {
            float rotatedX = (float)(x * Math.Cos(angle) - y * Math.Sin(angle));
            float rotatedY = (float)(x * Math.Sin(angle) + y * Math.Cos(angle));
            return new PointF(rotatedX, rotatedY);
        }

        // Функция для рисования перекрестия
        private void DrawCross(Graphics g, PointF position)
        {
            g.DrawLine(Pens.White, position.X - crossSize / 2, position.Y, position.X + crossSize / 2, position.Y); // Горизонтальная линия
            g.DrawLine(Pens.White, position.X, position.Y - crossSize / 2, position.X, position.Y + crossSize / 2); // Вертикальная линия
        }

        // Функция для рисования координат
        private void DrawCoordinates(Graphics g, string label, float x, float y, PointF position)
        {
            string coordinates = $"{label}: ({x:F2}, {y:F2})";
            Font font = new Font("Arial", 8);
            SolidBrush brush = new SolidBrush(Color.White);
            // Рисуем координаты чуть ниже и справа от объекта
            g.DrawString(coordinates, font, brush, position.X + 20, position.Y + 20);
        }

        private List<PointF> tailPositions = new List<PointF>(); // Хранение точек хвоста

        private void UpdateTailPosition(Graphics g, float tailLengthInDegrees)
        {
            int tailSegments = (int)tailLengthInDegrees; // Количество сегментов хвоста

            // Если у нас ещё нет достаточно сегментов хвоста, добавляем текущую позицию планеты
            if (tailPositions.Count == 0 || tailPositions.Count < tailSegments)
            {
                tailPositions.Add(Planet.Location.ToPoint());
            }
            else
            {
                // Если хвост уже максимальной длины, удаляем самый старый сегмент и добавляем новый
                tailPositions.RemoveAt(0);
                tailPositions.Add(Planet.Location.ToPoint());
            }

            // Отрисовка хвоста
            for (int i = tailPositions.Count - 1; i > 0; i--)
            {
                float transparencyFactor = (float)(tailPositions.Count - i) / tailPositions.Count;
                int alpha = (int)(255 * transparencyFactor);
                Color tailColor = Color.FromArgb(255 - alpha, Color.Orange);  // Белый цвет с прозрачностью 95, 122, 151
                Pen tailPen = new Pen(tailColor, 2);  // Толщина линии хвоста

                if (tailPositions[i - 1] != new PointF(0, 0))
                {
                    // Рисуем линию между последовательными точками хвоста
                    g.DrawLine(tailPen, tailPositions[i], tailPositions[i - 1]);
                }
            }
        }

        private void SolarSystemForm_MouseMove(object sender, MouseEventArgs e)
        {
            crlCoordinates.Text = $"{e.Location.X}:{e.Location.Y}";
        }
    }
}
