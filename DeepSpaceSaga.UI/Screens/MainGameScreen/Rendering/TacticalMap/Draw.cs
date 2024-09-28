namespace DeepSpaceSaga.UI.Screens.MainGameScreen.Rendering.TacticalMap;

internal class Draw
{
    public static void DrawTacticalMapScreen(Graphics graphics, GameSessionData session, ScreenParameters screenParameters)
    {
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.Bicubic;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

        DrawGrid.Execute(graphics, screenParameters);
    }
}
