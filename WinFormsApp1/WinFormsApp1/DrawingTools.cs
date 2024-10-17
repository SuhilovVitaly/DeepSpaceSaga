using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WinFormsApp1;

internal class DrawingTools
{
    public static void SmoothGraphics(Graphics g)
    {
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.InterpolationMode = InterpolationMode.Bicubic;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
    }

    public static void DrawCelestialObject(Graphics g, CelestialObject celestialObject)
    {
        DrawObject(g, celestialObject);
        DrawInformation(g, celestialObject);
    }

    public static void DrawOrbit(Graphics g, CelestialObject celestialObject)
    {
        if (celestialObject.Type == CelestialObjectType.Sun) return;

        // Угол наклона орбиты в радианах
        float orbitAngleRadians = (float)(celestialObject.OrbitAngle * Math.PI / 180);

        // Центр орбиты относительно центрального объекта (Солнце или планета)
        float centerX = celestialObject.Barycenter.Location.X + celestialObject.FocalDistance * (float)Math.Cos(orbitAngleRadians);
        float centerY = celestialObject.Barycenter.Location.Y + celestialObject.FocalDistance * (float)Math.Sin(orbitAngleRadians);
        var centerOfOrbit = new PointF(centerX, centerY);

        // Прямоугольник, ограничивающий эллипс орбиты
        var orbitRect = new RectangleF(
            centerOfOrbit.X - celestialObject.SemiMajorAxis,
            centerOfOrbit.Y - celestialObject.SemiMinorAxis,
            2 * celestialObject.SemiMajorAxis,
            2 * celestialObject.SemiMinorAxis
        );

        // Создаем матрицу для вращения орбиты на угол наклона
        using Matrix matrix = new();
        matrix.RotateAt(celestialObject.OrbitAngle, centerOfOrbit);
        g.Transform = matrix;

        // Рисуем эллипс орбиты
        g.DrawEllipse(new Pen(celestialObject.OrbitColor), orbitRect);

        // Сбрасываем трансформацию графики
        g.ResetTransform();
    }

    private static void DrawObject(Graphics g, CelestialObject celestialObject)
    {
        if (celestialObject.Type == CelestialObjectType.Asteroid) return;

        var textureColor = celestialObject.Color;

        if(textureColor == Color.Empty)
        {
            textureColor = Color.Blue; 
        }

        // Рисуем CelestialObject
        g.FillEllipse(new SolidBrush(textureColor), celestialObject.Location.X - celestialObject.Radius, celestialObject.Location.Y - celestialObject.Radius, 2 * celestialObject.Radius, 2 * celestialObject.Radius);
    }

    private static void DrawInformation(Graphics g, CelestialObject celestialObject)
    {
        if (celestialObject.Type == CelestialObjectType.Asteroid) return;

        var angleToMassCenter = celestialObject.Angle * (180.0 / Math.PI);
        var deltaX = 0;
        var deltaY = 0;

        var drawPoint = new PointF(celestialObject.Location.X + celestialObject.Radius + deltaX, celestialObject.Location.Y + celestialObject.Radius + deltaY);
        
        //g.DrawLine(new Pen(Color.White), celestialObject.Location.ToPoint(), drawPoint);

        string label = $"{celestialObject.Name} ({celestialObject.Location.X:F2}, {celestialObject.Location.Y:F2})";
        Font font = new Font("Arial", 8);
        SolidBrush brush = new SolidBrush(Color.White);
        // Рисуем координаты чуть ниже и справа от объекта
        g.DrawString(label, font, brush, drawPoint);
    }

}
