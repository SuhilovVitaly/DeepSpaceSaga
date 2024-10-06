using DeepSpaceSaga.UI.Render.Model;

namespace DeepSpaceSaga.UI;

public class GlobalResources
{
    public Draw DrawTool { get; set; } = new Draw();

    public GlobalResources(ScreenParameters screenParameters)
    {
        DrawTool.Initialization(screenParameters);
    }
}
