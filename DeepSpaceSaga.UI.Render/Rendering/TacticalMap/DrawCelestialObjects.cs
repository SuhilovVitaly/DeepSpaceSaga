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
                case CelestialObjectTypes.Container:
                    DrawContainerObject(screenInfo, currentObject, session);
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

        DrawTools.FillEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);
        DrawTools.DrawEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);
        DrawTools.DrawEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 8, color);
    }

    private static void DrawCelestialObject(IScreenInfo screenInfo, ICelestialObject celestialObject, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());
        var color = celestialObject.GetColor();

        DrawTools.FillEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);
        DrawTools.DrawEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);

        if (celestialObject.IsPreScanned)
        {
            DrawCelestialObjectInfo(screenInfo, celestialObject, color, session);
        }

    }

    private static void DrawContainerObject(IScreenInfo screenInfo, ICelestialObject celestialObject, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());
        var color = celestialObject.GetColor();

        DrawTools.FillEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);
        DrawTools.DrawEllipse(screenInfo, screenCoordinates.X, screenCoordinates.Y, 4, color);

        if (celestialObject.IsPreScanned)
        {
            DrawCelestialObjectInfo(screenInfo, celestialObject, color, session);
        }
    }

    private static void DrawCelestialObjectInfo(IScreenInfo screenInfo, ICelestialObject celestialObject, SpaceMapColor color, GameSession session)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());

        var startLabel = GeometryTools.Move(screenCoordinates, 45, LabelDirection(celestialObject));

        DrawTools.DrawLine(screenInfo, new SpaceMapColor(32, 32, 32), screenCoordinates, new SpaceMapPoint(startLabel.X, startLabel.Y + 15));

        DrawTools.FillRectangle(screenInfo, new SpaceMapColor(Color.FromArgb(22, 22, 22)), startLabel, 120, 18);
        DrawTools.FillRectangle(screenInfo, new SpaceMapColor(Color.FromArgb(52, 52, 52)), startLabel.X, startLabel.Y + 15, 120, 4);

        if (session.Metrics.Turn % 2 == 0)
        {
            DrawTools.FillRectangle(screenInfo, new SpaceMapColor(Color.FromArgb(160, 90, 0)), startLabel.X, startLabel.Y + 3, 8, 8);
        }
        else
        {
            DrawTools.FillRectangle(screenInfo, new SpaceMapColor(Color.WhiteSmoke), startLabel.X, startLabel.Y + 3, 8, 8);
        }

        var label = celestialObject.IsPreScanned ? celestialObject.Name : "Unknown Celestial Object";

        DrawTools.DrawString(screenInfo, label, new Font("Tahoma", 12), color, new RectangleF(startLabel.X + 15, startLabel.Y + 12, 190, 50));
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
