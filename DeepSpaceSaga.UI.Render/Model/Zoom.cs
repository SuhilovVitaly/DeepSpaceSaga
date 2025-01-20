namespace DeepSpaceSaga.UI.Render.Model;

public class Zoom : IZoom
{
    public int Size { get; private set; } = 20;

    public event Action? OnZoomIn;
    public event Action? OnZoomOut;

    public Zoom(int size)
    {
        Size = size;
    }    

    public void In()
    {
        switch (Size)
        {
            case 250:
                Size = 200;
                break;

            case 500:
                Size = 250;
                break;

            case 1000:
                Size = 500;
                break;

            case 2000:
                Size = 1000;
                break;

            case 4000:
                Size = 2000;
                break;

            default:
                break;
        }

        OnZoomIn?.Invoke();
    }

    public void Out()
    {
        switch (Size)
        {
            case 200:
                Size = 250;
                break;

            case 250:
                Size = 500;
                break;

            case 500:
                Size = 1000;
                break;

            case 1000:
                Size = 2000;
                break;

            case 2000:
                Size = 4000;
                break;

            default:
                break;
        }

        OnZoomOut?.Invoke();
    }
}
