namespace DeepSpaceSaga.UI.Render.Model;

public interface IZoom
{
    int Size { get; }
    void In();
    void Out();
    event Action? OnZoomIn;
    event Action? OnZoomOut;
}
