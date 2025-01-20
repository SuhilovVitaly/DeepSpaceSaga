namespace DeepSpaceSaga.UI;

public class GlobalResources : IDisposable
{
    public Draw DrawTool { get; set; } = new Draw();

    public GlobalResources()
    {
       
    }

    public void Dispose()
    {
        // Освобождение ресурсов
    }
}
