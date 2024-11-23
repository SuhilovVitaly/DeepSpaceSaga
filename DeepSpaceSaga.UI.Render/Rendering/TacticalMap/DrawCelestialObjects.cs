using DeepSpaceSaga.Common.Universe.Entities.CelestialObjects;

namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawCelestialObjects
{
    public static void Execute(Graphics graphics, IScreenInfo screenInfo, GameSession session)
    {
        foreach (var currentObject in session.SpaceMap.GetCelestialObjects())
        {
            switch (currentObject.Types)
            {
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.None:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.PointInMap:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.Asteroid:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.Station:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.SpaceshipPlayer:
                    DrawPlayerSpaceship(graphics, session, screenInfo, currentObject);
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.SpaceshipNpcNeutral:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.SpaceshipNpcEnemy:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.SpaceshipNpcFriend:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.Missile:
                    break;
                case Common.Universe.Entities.CelestialObjects.CelestialObjectTypes.Explosion:
                    break;
            }
        }
    }

    private static void DrawPlayerSpaceship(Graphics graphics, GameSession session, IScreenInfo screenInfo, ICelestialObject spaceShip)
    {
        var screenCoordinates = UiTools.ToScreenCoordinates(screenInfo, spaceShip.Location());
        var color = Color.DarkOliveGreen;

        graphics?.FillEllipse(new SolidBrush(color), screenCoordinates.X - 2, screenCoordinates.Y - 2, 4, 4);
        graphics.DrawEllipse(new Pen(color), screenCoordinates.X - 4, screenCoordinates.Y - 4, 8, 8);


        graphics.DrawEllipse(new Pen(color), screenCoordinates.X - 8, screenCoordinates.Y - 8, 16, 16);
    }
}
