namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawDirections
{
    public static void Execute(IScreenInfo screenInfo, GameManager session)
    {
        foreach (var currentObject in session.GetCelestialMap().GetCelestialObjects())
        {
            DrawDirection(screenInfo, currentObject);
        }
    }

    private static void DrawDirection(IScreenInfo screenInfo, ICelestialObject currentObject)
    {
        GeneralGraphics.DrawLongLine(screenInfo, currentObject, Color.FromArgb(22, 22, 22));
        GeneralGraphics.DrawArrow(screenInfo, currentObject, currentObject.GetColor());
    }
}
