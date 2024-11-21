namespace WinFormsApp1
{
    internal class BaseCelestialObject
    {
        // Положение объекта на форме
        public PointF Position { get; set; }

        // Направление движения объекта (в градусах)
        public float Direction { get; set; }

        // Скорость движения объекта
        public float Velocity { get; set; }

        // Agility degree per second
        public float Agility { get; set; }

        // Имя объекта
        public string Name { get; set; }

        // Цвет объекта
        public Color Color { get; set; }

        // Конструктор по умолчанию
        public BaseCelestialObject()
        {

        }
        public BaseCelestialObject(string name, PointF position, float direction, float velocity, Color color)
        {
            Name = name;
            Position = position;
            Direction = direction;
            Velocity = velocity;
            Color = color;
        }

        // Метод для обновления положения объекта в зависимости от скорости и направления
        public void UpdatePosition(float timeElapsed)
        {
            // Переводим направление в радианы для вычисления
            float radians = Direction * (float)Math.PI / 180f;

            // Обновляем координаты на основе скорости и направления
            Position = new PointF(
                Position.X + (float)(Velocity * Math.Cos(radians) * timeElapsed),
                Position.Y + (float)(Velocity * Math.Sin(radians) * timeElapsed)
            );
        }
    }

}
