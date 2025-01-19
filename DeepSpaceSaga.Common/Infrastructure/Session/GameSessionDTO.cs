namespace DeepSpaceSaga.Common.Infrastructure.Session;

public class GameSessionDTO
{
    public CelestialMap? CelestialMap { get; set;}

    public Journal? Logbook { get; set; }

    public GameState? State { get; set; } 

    public GameActionEvents? Events { get; set; }
}
