namespace DeepSpaceSaga.Universe;

[Serializable]
public class GameSession
{
    public int Id { get; set; }

    public bool IsRunning { get; set; } = false;

    public int Turn { get; set; } = 1;

    public int TurnTick { get; set; } = 0;

    public CelestialMap SpaceMap { get; set; } = new CelestialMap(new List<ICelestialObject>());
}
