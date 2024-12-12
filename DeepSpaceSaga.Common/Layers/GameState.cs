namespace DeepSpaceSaga.Common.Layers;

public class GameState
{
    public bool IsPaused { get; set; } = true;

    public int Speed { get; private set; } = 1;

    public void SetSpeed(int speed)
    {
        Speed = speed;
    }
}
