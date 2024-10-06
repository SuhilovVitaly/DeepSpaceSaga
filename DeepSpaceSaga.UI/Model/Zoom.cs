namespace DeepSpaceSaga.UI.Model;

public class Zoom
{
    public Zoom(int size)
    {
        Size = size;
    }

    public int Size { get; private set; } = 1000;

    public void In()
    {
        switch (Size)
        {
            case 500:
                Size = 250;
                break;

            case 1000:
                Size = 500;
                break;

            case 2000:
                Size = 1000;
                break;

            default:
                break;
        }
    }

    public void Out()
    {
        switch (Size)
        {
            case 250:
                Size = 500;
                break;

            case 500:
                Size = 1000;
                break;

            case 1000:
                Size = 2000;
                break;

            default:
                break;
        }
    }
}
