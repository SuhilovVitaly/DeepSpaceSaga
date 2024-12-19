namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation.Exceptions;

public class InvalidSessionException : TurnCalculationException
{
    public InvalidSessionException(string sessionId) 
        : base(sessionId, $"Invalid session: {sessionId}")
    {
    }

    public InvalidSessionException(string sessionId, string message) 
        : base(sessionId, message)
    {
    }
} 