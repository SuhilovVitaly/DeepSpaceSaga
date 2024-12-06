namespace DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

public class Draw
{
    public void DrawTacticalMapScreen(GameSession session, OuterSpace outerSpace, ScreenParameters screenParameters)
    {
        DrawGrid.Execute(screenParameters);

        DrawSpaceScanner.Execute(screenParameters, session);

        DrawDirections.Execute(screenParameters, session);        

        DrawCelestialObjects.Execute(screenParameters, session);

        DrawModulesActions.Execute(screenParameters, session);

        DrawInteraction.Execute(screenParameters, outerSpace, session);
    }
}
