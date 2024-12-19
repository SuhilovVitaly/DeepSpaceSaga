using DeepSpaceSaga.Common.GameState;

namespace DeepSpaceSaga.Server.GameState;

public interface IGameStateManager
{
    Task<GameState> GetGameStateAsync(string sessionId);
    Task<bool> UpdateGameStateAsync(string sessionId, GameState newState);
    Task<bool> IsGameActiveAsync(string sessionId);
}

public class GameState
{
    public string SessionId { get; set; }
    public GameStatus Status { get; set; }
    public DateTime LastUpdateTime { get; set; }
} 