using DeepSpaceSaga.UI.Render.Rendering.TacticalMap;

namespace DeepSpaceSaga.UI;

public class GlobalResources
{
    public Draw DrawTool { get; set; } = new Draw();

    public GlobalResources(ScreenParameters screenParameters)
    {
        DrawTool.Initialization(screenParameters);
    }
}
