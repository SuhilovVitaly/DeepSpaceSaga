namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawSpaceScanner
{
    public static void Execute(IScreenInfo screenInfo, GameSession session)
    {
        var spacecraft = session.GetPlayerSpaceShip();
        var location = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());

        if (spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() is not IScanner scannerModule) return;

        DrawTools.FillEllipse(screenInfo, location.X, location.Y, (float)(scannerModule.ScanRange), new SpaceMapColor(Color.FromArgb(10, 0, 255, 0)));
        DrawTools.DrawEllipse(screenInfo, location.X, location.Y, (float)(scannerModule.ScanRange), Colors.LightGray);

        if(session.IsRunning == false) return;

        if(scannerModule.IsReloaded == true) return;

        var radius = CalculateDistanceCovered(scannerModule.ReloadTime, scannerModule.Reloading, scannerModule.ScanRange);

        //DrawTools.DrawEllipse(screenInfo, location.X, location.Y, radius, new SpaceMapColor(Color.OrangeRed));
    }

    private static float CalculateDistanceCovered(double cycleDuration, double currentSecond, double totalDistance)
    {
        if (cycleDuration <= 0)
        {
            throw new ArgumentException("Cycle duration must be greater than zero.", nameof(cycleDuration));
        }
        if (currentSecond < 0 || currentSecond > cycleDuration)
        {
            throw new ArgumentException("Current second must be within the cycle duration.", nameof(currentSecond));
        }

        // Расчет пройденного расстояния
        float distanceCovered = (float)((currentSecond / cycleDuration) * totalDistance);

        return distanceCovered;
    }
}
