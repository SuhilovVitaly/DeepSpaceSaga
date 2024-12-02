﻿namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawModulesActions
{
    public static void Execute(IScreenInfo screenInfo, GameSession session)
    {
        var spacecraft = session.GetPlayerSpaceShip();
        

        foreach (var module in spacecraft.Modules)
        {
            if (module.IsCalculated) continue;

            switch (module.Category)
            {
                case Category.Weapon:
                    break;
                case Category.Shield:
                    break;
                case Category.Propulsion:
                    break;
                case Category.Reactor:
                    break;
                case Category.SpaceScanner:
                    DrawSpaceScanner(screenInfo, session, module, spacecraft);
                    break;
                case Category.DeepScanner:
                    break;
            }
        }
    }

    private static void DrawSpaceScanner(IScreenInfo screenInfo, GameSession session, IModule module, ISpacecraft spacecraft)
    {
        var spacecraftLocation = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());
        var targetLocation = UiTools.ToScreenCoordinates(screenInfo, session.GetCelestialObject(module.TargetId).GetLocation());
        var direction = GeometryTools.Azimuth(spacecraftLocation, targetLocation);
        var direction1 = GeometryTools.Azimuth(targetLocation, spacecraftLocation);

        screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.DarkOrange, 1), targetLocation.X - 30, targetLocation.Y - 30, 60, 60);

        var locationConnector = GeometryTools.Move(targetLocation, 30, direction);
        var locationConnector2 = GeometryTools.Move(spacecraftLocation, 30, direction1);

        screenInfo.GraphicSurface?.DrawLine(new Pen(Color.DarkOrange, 1), locationConnector, locationConnector2);
    }
}
