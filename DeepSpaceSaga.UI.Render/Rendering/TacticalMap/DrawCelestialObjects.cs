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
                    break;
                case CelestialObjectTypes.Station:
                    break;
                case CelestialObjectTypes.SpaceshipPlayer:
                    DrawPlayerSpaceship(session, screenInfo, currentObject);
                    break;
                case CelestialObjectTypes.SpaceshipNpcNeutral:
                    break;
                case CelestialObjectTypes.SpaceshipNpcEnemy:
                    break;
                case CelestialObjectTypes.SpaceshipNpcFriend:
                    break;
                case CelestialObjectTypes.Missile:
                    break;
                case CelestialObjectTypes.Explosion:
                    break;
            }
        }
    }

    private static void DrawPlayerSpaceship(GameSession session, IScreenInfo screenInfo, ICelestialObject spaceShip)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, spaceShip.GetLocation());
        var color = Color.DarkOliveGreen;

        screenInfo.GraphicSurface?.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);


        screenInfo.GraphicSurface?.DrawEllipse(new Pen(color), screenCoordinates.X - 8, screenCoordinates.Y - 8, 16, 16);
    }
}
