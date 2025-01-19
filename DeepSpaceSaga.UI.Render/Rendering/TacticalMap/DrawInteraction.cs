namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class DrawInteraction
{
    public static void Execute(IScreenInfo screenInfo, OuterSpace outerSpace, GameSessionDTO session)
    {
        if (session.GetCelestialObject(outerSpace.SelectedObjectId) is null)
        {
            outerSpace.CleanSelectedObject();
        }

        if (session.GetCelestialObject(outerSpace.ActiveObjectId) is null)
        {
            outerSpace.CleanActiveObject();
        }


        if (outerSpace.ActiveObjectId > 0 && outerSpace.ActiveObjectId != outerSpace.SelectedObjectId)
        {
            var targetLocation = UiTools.ToScreenCoordinates(screenInfo, session.GetCelestialObject(outerSpace.ActiveObjectId).GetLocation());

            screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.DarkOrange, 1), targetLocation.X, targetLocation.Y, 25, 25);
        }

        if (outerSpace.SelectedObjectId > 0)
        {
            var targetLocation = UiTools.ToScreenCoordinates(screenInfo, session.GetCelestialObject(outerSpace.SelectedObjectId).GetLocation());

            screenInfo.GraphicSurface?.DrawEllipse(new Pen(Color.OrangeRed, 1), targetLocation.X, targetLocation.Y, 25, 25);
        }
    }
}
