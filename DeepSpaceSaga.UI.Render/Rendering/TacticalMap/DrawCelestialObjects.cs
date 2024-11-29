using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawCelestialObjects
{
    public static void Execute(IScreenInfo screenInfo, GameSession session)
    {
        foreach (var currentObject in session.SpaceMap.GetCelestialObjects())
        {
            switch (currentObject.Types)
            {
                case CelestialObjectTypes.None:
                    break;
                case CelestialObjectTypes.PointInMap:
                    break;
                case CelestialObjectTypes.Asteroid:
                    DrawCelestialObject(screenInfo, currentObject, session);
                    break;
                case CelestialObjectTypes.Station:
                    DrawCelestialObject(screenInfo, currentObject, session);
                    break;
                case CelestialObjectTypes.SpaceshipPlayer:
                    DrawPlayerSpaceship(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    DrawCelestialObject(screenInfo, currentObject, session);
                    break;
                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    DrawCelestialObject(screenInfo, currentObject, session);
                    break;
                case CelestialObjectTypes.SpaceshipNpcFriend:
                    DrawCelestialObject(screenInfo, currentObject, session);
                    break;
                case CelestialObjectTypes.Missile:
                    break;
                case CelestialObjectTypes.Explosion:
                    break;
            }
        }
    }

    private static void DrawPlayerSpaceship(IScreenInfo screenInfo, ICelestialObject spaceShip)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, spaceShip.GetLocation());
        var color = spaceShip.GetColor();

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);

        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 8, screenCoordinates.Y - 8, 16, 16);
    }

    private static void DrawCelestialObject(IScreenInfo screenInfo, ICelestialObject celestialObject, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());
        var color = celestialObject.GetColor();

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);

        DrawCelestialObjectInfo(screenInfo, celestialObject, color, session);
    }

    private static void DrawCelestialObjectInfo(IScreenInfo screenInfo, ICelestialObject celestialObject, Color color, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());

        var startLabel = GeometryTools.Move(screenCoordinates, 45, LabelDirection(celestialObject));

        screenInfo.GraphicSurface?.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), screenCoordinates, new PointF(startLabel.X, startLabel.Y + 15));

        screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), startLabel.X - 3, startLabel.Y - 3, 120, 18);
        screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), startLabel.X - 3, startLabel.Y + 15, 120, 4);

        if(session.Turn % 2 == 0)
        {
            screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(160, 90, 0)), startLabel.X, startLabel.Y + 3, 8, 8);
        }
        else
        {
            screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(120, 90, 0)), startLabel.X, startLabel.Y + 3, 8, 8);
        }
        

        screenInfo.GraphicSurface?.DrawString($"{celestialObject.Name}", new Font("Tahoma", 7), new SolidBrush(color), new RectangleF(startLabel.X + 15, startLabel.Y, 190, 50));
    }

    private static int LabelDirection(ICelestialObject celestialObject)
    {
        var direction = 0;

        if(celestialObject.Direction > 0 && celestialObject.Direction < 90)
        {
            return 270 + 90 / 2;
        }

        if (celestialObject.Direction > 90 && celestialObject.Direction < 180)
        {
            return 270 + 90 / 2;
        }

        if (celestialObject.Direction > 180 && celestialObject.Direction < 270)
        {
            return 45;
        }

        if (celestialObject.Direction > 270 && celestialObject.Direction < 360)
        {
            return 135;
        }


        return direction;
    }
}
