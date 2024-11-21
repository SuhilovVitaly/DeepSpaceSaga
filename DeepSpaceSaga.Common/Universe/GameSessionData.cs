namespace DeepSpaceSaga.Universe;

public class GameSessionData
{
    public bool IsRunning { get; set; } = false;

    public int Turn {  get; set; }

    public int TurnTick { get; set; }
}
