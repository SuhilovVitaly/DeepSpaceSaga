using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class SolarSystemForm : Form
    {
        private Timer gameTimer;
        private Timer calculateTimer;

        List<CelestialObject> celestialObjects;
        private Bitmap offscreenBitmap;

        public SolarSystemForm()
        {
            InitializeComponent();
            celestialObjects = CelestialObjectsLoader.GetCelestialObjects();
            InitSolarSystem();
        }

        private void InitSolarSystem()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;

            DrawBackgroundWithorbits();

            // Настройка таймера
            gameTimer = new Timer
            {
                Interval = 16 // ~60 FPS
            };

            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            calculateTimer = new Timer
            {
                Interval = 200 // ~60 FPS
            };

            calculateTimer.Tick += GameTurnCalculate;
            calculateTimer.Start();
        }

        private void GameTurnCalculate(object? sender, EventArgs e)
        {
            foreach (var celestialObject in celestialObjects.OrderByDescending(obj => obj.Type).ToList())
            {
                celestialObject.UpdateLocation();
                celestialObject.UpdateAngle();
            }
        }

        private void DrawBackgroundWithorbits()
        {
            if (ClientSize.Width == 0) return;

            offscreenBitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            var offscreenGraphics = Graphics.FromImage(offscreenBitmap);

            DrawingTools.SmoothGraphics(offscreenGraphics);

            foreach (var celestialObject in celestialObjects.OrderByDescending(obj => obj.Type).ToList())
            {
                DrawingTools.DrawOrbit(offscreenGraphics, celestialObject);
            }
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

            DrawingTools.SmoothGraphics(g);

            g.DrawImage(offscreenBitmap, 0, 0, ClientSize.Width, ClientSize.Height);

            foreach (var celestialObject in celestialObjects.OrderByDescending(obj => obj.Type).ToList())
            {
                DrawingTools.DrawCelestialObject(g, celestialObject);
            }
        }

        private void SolarSystemForm_MouseMove(object sender, MouseEventArgs e)
        {
            crlCoordinates.Text = $"{e.Location.X}:{e.Location.Y}";
        }

        private void SolarSystemForm_Resize(object sender, EventArgs e)
        {
            DrawBackgroundWithorbits();
        }
    }
}
