namespace DeepSpaceSaga.Common.Layers;

public class GameSpeed
{
    public bool IsPaused { get; set; } = false;

    public int Speed { get; private set; } = 1;

    private const int MaxSpeed = 3;

    public void Increase()
    {
        Speed = Speed + 1 > MaxSpeed ? MaxSpeed : Speed + 1;
    }

    public void Decrease()
    {
        Speed = Speed - 1 <= 0 ? 1 : Speed - 1;
    }
}
