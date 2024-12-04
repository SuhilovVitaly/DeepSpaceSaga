using DeepSpaceSaga.UI.Render.Extensions;

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

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X, screenCoordinates.Y, 2, 2);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X , screenCoordinates.Y, 4, 4);

        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X , screenCoordinates.Y, 8, 8);
    }

    private static void DrawCelestialObject(IScreenInfo screenInfo, ICelestialObject celestialObject, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());
        var color = celestialObject.GetColor();

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X , screenCoordinates.Y, 4, 4);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X, screenCoordinates.Y , 4, 4);

        if (celestialObject.IsPreScanned)
        {
            DrawCelestialObjectInfo(screenInfo, celestialObject, color, session);
        }

    }

    private static void DrawCelestialObjectInfo(IScreenInfo screenInfo, ICelestialObject celestialObject, Color color, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());

        var startLabel = GeometryTools.Move(screenCoordinates, 45, LabelDirection(celestialObject));

        screenInfo.GraphicSurface?.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), screenCoordinates, new PointF(startLabel.X, startLabel.Y + 15));

        screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), startLabel.X, startLabel.Y, 120, 18);
        screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), startLabel.X, startLabel.Y + 15, 120, 4);

        if (session.Turn % 2 == 0)
        {
            screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.FromArgb(160, 90, 0)), startLabel.X, startLabel.Y + 3, 8, 8);
        }
        else
        {
            screenInfo.GraphicSurface?.FillRectangle(new SolidBrush(Color.WhiteSmoke), startLabel.X, startLabel.Y + 3, 8, 8);
        }

        var label = celestialObject.IsPreScanned ? celestialObject.Name : "Unknown Celestial Object";

        screenInfo.GraphicSurface?.DrawString($"{label}", new Font("Tahoma", 12), new SolidBrush(color), new RectangleF(startLabel.X + 15, startLabel.Y + 12, 190, 50));
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
