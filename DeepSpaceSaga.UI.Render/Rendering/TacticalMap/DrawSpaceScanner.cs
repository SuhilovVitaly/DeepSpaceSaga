namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawSpaceScanner
{
    public static void Execute(IScreenInfo screenInfo, GameSession session)
    {
        var color = new SKColor(0, 255, 0, 10);// Color.FromArgb(5, 0, 255, 0);

        var spacecraft = session.GetPlayerSpaceShip();
        var location = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());

        if (spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() is not IScanner scannerModule) return;

        var rectangle = new RectangleF(
            (float)(location.X - scannerModule.ScanRange / 2), 
            (float)(location.Y - scannerModule.ScanRange / 2), 
            (float)(scannerModule.ScanRange), 
            (float)(scannerModule.ScanRange));

        using var paint = new SKPaint
        {
            Color = color,
            IsAntialias = true,
            Style = SKPaintStyle.Fill
        };

        screenInfo.GraphicSurface.DrawCircle(location.X, location.Y, (float)(scannerModule.ScanRange / 2), paint);

        using var paintLine = new SKPaint
        {
            Color = color,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };
        screenInfo.GraphicSurface.DrawCircle(location.X, location.Y, (float)(scannerModule.ScanRange / 2), paintLine);
    }
}
