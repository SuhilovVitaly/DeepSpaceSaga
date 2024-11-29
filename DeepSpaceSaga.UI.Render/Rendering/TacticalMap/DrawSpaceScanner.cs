namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawSpaceScanner
{
    public static void Execute(IScreenInfo screenInfo, GameSession session)
    {
        var color = Color.FromArgb(15, 0, 255, 0);

        var spacecraft = session.GetPlayerSpaceShip();
        var location = UiTools.ToScreenCoordinates(screenInfo, spacecraft.GetLocation());

        if (spacecraft.GetModules(Category.SpaceScanner).FirstOrDefault() is not IScanner scannerModule) return;

        var rectangle = new RectangleF(
            (float)(location.X - scannerModule.ScanRange / 2), 
            (float)(location.Y - scannerModule.ScanRange / 2), 
            (float)(scannerModule.ScanRange), 
            (float)(scannerModule.ScanRange));

        using var brush = new SolidBrush(color); // Почти прозрачный зелёный

        //screenInfo.GraphicSurface?.FillEllipse(brush, rectangle);
        screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.FromArgb(22, 22, 22), 1), rectangle);
        //screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.FromArgb(12, 22, 22), 4), rectangle);
        //screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.FromArgb(42, 22, 22), 2), rectangle);

        //using var gradientBrush = CreateOptimizedGradientBrush(rectangle);
        //screenInfo.GraphicSurface?.FillEllipse(gradientBrush, rectangle);
    }

    private static PathGradientBrush CreateOptimizedGradientBrush(RectangleF rectangle)
    {
        //var color = Color.FromArgb(5, 75, 100);
        var color = Color.FromArgb(0, 255, 0);

        // Минимизируем количество создаваемых объектов
        var path = new GraphicsPath();
        path.AddEllipse(rectangle);

        var gradientBrush = new PathGradientBrush(path)
        {
            CenterColor = Color.FromArgb(200, color), // Насыщенный зелёный в центре
            SurroundColors = [Color.FromArgb(0, color)] // Почти прозрачный по краям
        };

        path.Dispose(); // Немедленно освобождаем ресурсы, связанные с графическим путем
        return gradientBrush;
    }
}
