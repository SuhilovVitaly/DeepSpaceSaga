namespace DeepSpaceSaga.Common.Layers;

public class GameSpeed
{
    public bool IsPaused { get; set; } = true;

    public int Speed { get; private set; } = 1;

    public void SetSpeed(int speed)
    {
        Speed = speed;
    }
}
