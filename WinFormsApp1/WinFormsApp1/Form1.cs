using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Timer gameLogicTimer;
        private Timer renderTimer;
        private const int LogicUpdateInterval = 200; // Интервал логики в миллисекундах
        private const int RenderUpdateInterval = 16; // Интервал рендера (примерно 60 FPS)

        private Stopwatch stopwatch;
        private Pen gridPen = new Pen(Color.FromArgb(22, 22, 22)); // Вынесен объект Pen

        private BaseCelestialObject spacecraft;

        private BaseCelestialObject asteroid;

        public Form1()
        {
            InitializeComponent();

            GameInitialization();
            // Настройка формы
            this.DoubleBuffered = true;
            this.Width = 800;
            this.Height = 600;

            // Инициализация таймера для логики
            gameLogicTimer = new Timer();
            gameLogicTimer.Interval = LogicUpdateInterval;
            gameLogicTimer.Tick += GameLogicUpdate;

            // Инициализация таймера для рендера
            renderTimer = new Timer();
            renderTimer.Interval = RenderUpdateInterval;
            renderTimer.Tick += RenderFrame;

            // Запуск таймеров
            gameLogicTimer.Start();
            renderTimer.Start();

            // Инициализация объекта Stopwatch для измерения времени
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private void GameInitialization()
        {
            spacecraft = new BaseCelestialObject
            {
                Color = Color.WhiteSmoke,
                Position = new PointF(200, 200),
                Direction = 170,
                Agility = 2,
                Velocity = 20,
                Name = "Ajiax"
            };

            asteroid = new BaseCelestialObject
            {
                Color = Color.WhiteSmoke,
                Position = new PointF(400, 400),
                Direction = 125,
                Agility = 0,
                Velocity = 0,
                Name = "AST-01"
            };
        }

        private void GameLogicUpdate(object sender, EventArgs e)
        {
            // Вычисляем угол между космическим кораблём и астероидом
            float targetAngle = (float)(Math.Atan2(asteroid.Position.Y - spacecraft.Position.Y, asteroid.Position.X - spacecraft.Position.X) * 180 / Math.PI);

            // Нормализуем угол направления космического корабля
            float angleDifference = targetAngle - spacecraft.Direction;
            if (angleDifference > 180) angleDifference -= 360;
            if (angleDifference < -180) angleDifference += 360;

            // Рассчитываем время, необходимое для синхронизации направления
            float timeToSyncDirection = Math.Abs(angleDifference) / spacecraft.Agility;

            // Рассчитываем расстояние, на котором должна начаться синхронизация (скорость корабля * время на синхронизацию направления)
            float syncDistance = spacecraft.Velocity * timeToSyncDirection;

            // Вычисляем текущее расстояние между кораблём и астероидом
            float distanceToAsteroid = DistanceBetween(spacecraft.Position, asteroid.Position);

            // Если расстояние до астероида меньше или равно расстоянию синхронизации
            if (distanceToAsteroid <= syncDistance)
            {
                // Медленно меняем направление на направление астероида
                if (Math.Abs(angleDifference) > spacecraft.Agility)
                {
                    spacecraft.Direction += (angleDifference > 0) ? spacecraft.Agility : -spacecraft.Agility;
                }
                else
                {
                    spacecraft.Direction = targetAngle;
                }

                // Когда корабль близок к астероиду, синхронизируем скорость
                if (distanceToAsteroid < 10) // 10 пикселей — порог приближения
                {
                    spacecraft.Velocity = asteroid.Velocity;
                }
            }

            // Обновляем позицию космического корабля в зависимости от направления и скорости
            spacecraft.UpdatePosition(0.2f); // 0.2f соответствует обновлению раз в 200 мс

            Console.WriteLine($"Spacecraft Direction: {spacecraft.Direction}, Position: {spacecraft.Position}, Distance to asteroid: {distanceToAsteroid}");
        }


        private float DistanceBetween(PointF p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        private void RenderFrame(object sender, EventArgs e)
        {
            // Обновляем форму, вызывая метод OnPaint
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Задание черного фона
            g.Clear(Color.Black);

            // Отрисовка сетки
            int cellSize = 20; // Размер одной клетки
            DrawGrid(g, cellSize);

            // Отрисовка траектории от космического корабля до астероида
            DrawTrajectory(g, spacecraft, asteroid);  // Красная линия траектории

            // Отрисовка небесных объектов
            DrawCelestialObject(g, spacecraft, 10); // Радиус объекта 10 пикселей
            DrawDirectionArrow(g, spacecraft, 20);  // Длина стрелки 20 пикселей
            DrawCelestialObject(g, asteroid, 10);   // Радиус объекта 10 пикселей
            DrawDirectionArrow(g, asteroid, 20);    // Длина стрелки 20 пикселей

            // Вывод FPS
            float fps = 1000f / stopwatch.ElapsedMilliseconds;
            g.DrawString($"FPS: {fps:0.00}", new Font("Arial", 16), Brushes.White, 10, 10);

            stopwatch.Restart();
        }

        private void DrawGrid(Graphics g, int cellSize)
        {
            int columns = (int)Math.Ceiling((double)this.ClientSize.Width / cellSize);
            int rows = (int)Math.Ceiling((double)this.ClientSize.Height / cellSize);

            // Рисуем горизонтальные и вертикальные линии
            for (int i = 0; i <= rows; i++)
            {
                // Горизонтальные линии
                g.DrawLine(gridPen, 0, i * cellSize, this.ClientSize.Width, i * cellSize);
            }

            for (int i = 0; i <= columns; i++)
            {
                // Вертикальные линии
                g.DrawLine(gridPen, i * cellSize, 0, i * cellSize, this.ClientSize.Height);
            }
        }

        private void DrawCelestialObject(Graphics g, BaseCelestialObject obj, int radius)
        {
            Brush brush = new SolidBrush(obj.Color);

            // Определяем координаты центра объекта
            float x = obj.Position.X - radius;
            float y = obj.Position.Y - radius;

            // Рисуем круг (небесный объект)
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
        }

        private void DrawDirectionArrow(Graphics g, BaseCelestialObject obj, int arrowLength)
        {
            Pen arrowPen = new Pen(obj.Color, 2); // Стрелка рисуется цветом объекта

            // Определяем начальную точку стрелки — позиция объекта
            PointF start = obj.Position;

            // Определяем направление объекта в радианах
            float radians = obj.Direction * (float)Math.PI / 180f;

            // Вычисляем конечную точку стрелки на основе направления и длины стрелки
            PointF end = new PointF(
                start.X + (float)(arrowLength * Math.Cos(radians)),
                start.Y + (float)(arrowLength * Math.Sin(radians))
            );

            // Рисуем стрелку
            g.DrawLine(arrowPen, start, end);
        }

        private void DrawTrajectory(Graphics g, BaseCelestialObject spacecraft, BaseCelestialObject asteroid)
        {
            Pen trajectoryPen = new Pen(Color.Red, 2); // Линия траектории красного цвета

            // Начальная точка — позиция космического корабля
            PointF start = spacecraft.Position;

            // Конечная точка — позиция астероида
            PointF end = asteroid.Position;

            // Список точек для рисования траектории
            List<PointF> trajectoryPoints = new List<PointF>();
            trajectoryPoints.Add(start);

            // Начальные условия для симуляции
            PointF simulatedPosition = spacecraft.Position;
            float simulatedDirection = spacecraft.Direction;
            float simulatedVelocity = spacecraft.Velocity;

            // Пока не достигли астероида, продолжаем рассчитывать точки траектории
            while (DistanceBetween(simulatedPosition, asteroid.Position) > 10)
            {
                // Вычисляем угол между текущей симуляцией и астероидом
                float targetAngle = (float)(Math.Atan2(asteroid.Position.Y - simulatedPosition.Y, asteroid.Position.X - simulatedPosition.X) * 180 / Math.PI);

                // Нормализуем угол
                float angleDifference = targetAngle - simulatedDirection;
                if (angleDifference > 180) angleDifference -= 360;
                if (angleDifference < -180) angleDifference += 360;

                // Постепенно меняем направление в симуляции с учётом маневренности
                if (Math.Abs(angleDifference) > spacecraft.Agility)
                {
                    simulatedDirection += (angleDifference > 0) ? spacecraft.Agility : -spacecraft.Agility;
                }
                else
                {
                    simulatedDirection = targetAngle;
                }

                // Вычисляем новые координаты в симуляции на основе текущего направления и скорости
                float radians = simulatedDirection * (float)Math.PI / 180f;
                simulatedPosition = new PointF(
                    simulatedPosition.X + (float)(simulatedVelocity * 0.2f * Math.Cos(radians)), // 0.2f для шага времени
                    simulatedPosition.Y + (float)(simulatedVelocity * 0.2f * Math.Sin(radians))
                );

                // Добавляем точку в траекторию
                trajectoryPoints.Add(simulatedPosition);
            }

            // Рисуем траекторию по рассчитанным точкам
            for (int i = 0; i < trajectoryPoints.Count - 1; i++)
            {
                g.DrawLine(trajectoryPen, trajectoryPoints[i], trajectoryPoints[i + 1]);
            }
        }

    }
}

