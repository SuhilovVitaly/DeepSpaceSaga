namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

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
                case Category.MiningLaser:
                    DrawMiningLaser(screenInfo, session, module, spacecraft);
                    break;
            }
        }
    }
    private static void DrawMiningLaser(IScreenInfo screenInfo, GameSession session, IModule module, ISpacecraft spacecraft)
    {
        if (module.IsActive == false)
        {
            return;
        }

        var spacecraftLocation = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());
        var targetLocation = UiTools.ToScreenCoordinates(screenInfo, session.GetCelestialObject(module.TargetId).GetLocation());
        var direction = GeometryTools.Azimuth(spacecraftLocation, targetLocation);
        var direction1 = GeometryTools.Azimuth(targetLocation, spacecraftLocation);

        screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.DarkOrange, 1), targetLocation.X, targetLocation.Y, 15, 15);

        var locationConnector = GeometryTools.Move(targetLocation, 30, direction);
        var locationConnector2 = GeometryTools.Move(spacecraftLocation, 30, direction1);

        DrawTools.DrawLine(screenInfo, Colors.ModuleSpaceScannerConnector, locationConnector, locationConnector2);


        var startLabel = GeometryTools.Move(targetLocation, 45, LabelDirection(session.GetCelestialObject(module.TargetId)));

        DrawTools.DrawLine(screenInfo, new SpaceMapColor(32, 32, 32), targetLocation, new SpaceMapPoint(startLabel.X, startLabel.Y + 15));

        DrawTools.FillRectangle(screenInfo, new SpaceMapColor(Color.FromArgb(22, 22, 22)), startLabel, 120, 18);

        var label = $"Mining progress: ";

        DrawTools.DrawString(screenInfo, label, Fonts.SpaceMapLabels, Colors.ForeColorSpaceMap, new RectangleF(startLabel.X + 15, startLabel.Y + 12, 190, 50));

        var labelValue = $"{CalculateWorkPercentage(module.ReloadTime, module.Reloading)}%";

        DrawTools.DrawString(screenInfo, labelValue, Fonts.SpaceMapLabels, Colors.ForePercentColor, new RectangleF(startLabel.X + 15 + DrawTools.MeasureString(label, Fonts.SpaceMapLabels).Width, startLabel.Y + 12, 190, 50));
    }

    private static void DrawSpaceScanner(IScreenInfo screenInfo, GameSession session, IModule module, ISpacecraft spacecraft)
    {
        var spacecraftLocation = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());
        var targetLocation = UiTools.ToScreenCoordinates(screenInfo, session.GetCelestialObject(module.TargetId).GetLocation());
        var direction = GeometryTools.Azimuth(spacecraftLocation, targetLocation);
        var direction1 = GeometryTools.Azimuth(targetLocation, spacecraftLocation);

        var color = new SpaceMapColor(32, 32, 32);

        screenInfo.GraphicSurface?.DrawEllipse(Colors.ModuleSpaceScannerConnector, targetLocation.X , targetLocation.Y, 15, 15);

        var locationConnector = GeometryTools.Move(targetLocation, 30, direction);
        var locationConnector2 = GeometryTools.Move(spacecraftLocation, 30, direction1);

        DrawTools.DrawLine(screenInfo, Colors.ModuleSpaceScannerConnector, locationConnector, locationConnector2);


        var startLabel = GeometryTools.Move(targetLocation, 45, LabelDirection(session.GetCelestialObject(module.TargetId)));

        DrawTools.DrawLine(screenInfo, color, targetLocation, new SpaceMapPoint(startLabel.X, startLabel.Y + 15));

        DrawTools.FillRectangle(screenInfo, Colors.ForeBackgroundColorSpaceMap, startLabel, 160, 18);

        var label = $"Scanning progress: ";

        DrawTools.DrawString(screenInfo, label, Fonts.SpaceMapLabels, Colors.ForeColorSpaceMap, new RectangleF(startLabel.X + 15, startLabel.Y + 12, 190, 50));

        var x = DrawTools.MeasureString("Scanning progress: ", Fonts.SpaceMapLabels);

        var labelValue = $"{CalculateWorkPercentage(module.ReloadTime, module.Reloading)}%";

        DrawTools.DrawString(screenInfo, labelValue, Fonts.SpaceMapLabels, Colors.ForePercentColor, new RectangleF(startLabel.X + 15 + x.Width, startLabel.Y + 12, 190, 50));
    }

    public static double CalculateWorkPercentage(double totalTime, double currentTime)
    {
        if (totalTime <= 0)
        {
            throw new ArgumentException("Total time must be greater than zero.", nameof(totalTime));
        }
        if (currentTime < 0 || currentTime > totalTime)
        {
            return 100;
        }

        // Рассчитываем процент завершённого времени
        double percentage = (currentTime / totalTime) * 100;

        return Math.Round(percentage, 2);
    }

    private static int LabelDirection(ICelestialObject celestialObject)
    {
        var direction = 0;

        if (celestialObject.Direction > 0 && celestialObject.Direction < 90)
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
