namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawCelestialObjects
{
    public static void Execute(IScreenInfo screenInfo, GameManager session)
    {
        foreach (var currentObject in session.GetCelestialMap().GetCelestialObjects())
        {
            switch (currentObject.Types)
            {
                case CelestialObjectTypes.None:
                    break;
                case CelestialObjectTypes.PointInMap:
                    break;
                case CelestialObjectTypes.Asteroid:
                    DrawCelestialObject(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.Station:
                    DrawCelestialObject(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipPlayer:
                    DrawPlayerSpaceship(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    DrawCelestialObject(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    DrawCelestialObject(screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipNpcFriend:
                    DrawCelestialObject(screenInfo, currentObject);
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

    private static void DrawCelestialObject(IScreenInfo screenInfo, ICelestialObject celestialObject)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, celestialObject.GetLocation());
        var color = celestialObject.GetColor();

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);
    }
}
