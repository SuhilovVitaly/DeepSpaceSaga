namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

internal class DrawDirections
{
    public static void Execute(IScreenInfo screenInfo, GameSessionDTO session)
    {
        foreach (var currentObject in session.SpaceMap.GetCelestialObjects())
        {
            DrawDirection(screenInfo, currentObject);
        }
    }

    private static void DrawDirection(IScreenInfo screenInfo, ICelestialObject currentObject)
    {
        GeneralGraphics.DrawLongLine(screenInfo, currentObject, new SpaceMapColor(Color.FromArgb(22, 22, 22)));
        GeneralGraphics.DrawArrow(screenInfo, currentObject, currentObject.GetColor());
    }
}
