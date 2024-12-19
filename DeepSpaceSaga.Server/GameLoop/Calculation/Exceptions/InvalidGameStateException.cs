using DeepSpaceSaga.Common.GameState;

namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation.Exceptions;

public class InvalidGameStateException : TurnCalculationException
{
    public GameStatus CurrentStatus { get; }

    public InvalidGameStateException(string sessionId, GameStatus currentStatus) 
        : base(sessionId, $"Invalid game state: {currentStatus}")
    {
        CurrentStatus = currentStatus;
    }

    public InvalidGameStateException(string sessionId, GameStatus currentStatus, string message) 
        : base(sessionId, message)
    {
        CurrentStatus = currentStatus;
    }
} 