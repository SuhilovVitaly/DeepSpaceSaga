namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation.Exceptions;

public class TurnCalculationException : Exception
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(TurnCalculationException));

    public string SessionId { get; }

    public TurnCalculationException(string sessionId, string message) 
        : base(message)
    {
        SessionId = sessionId;
        _log.Error($"Turn calculation error for session {sessionId}: {message}");
    }

    public TurnCalculationException(string sessionId, string message, Exception innerException) 
        : base(message, innerException)
    {
        SessionId = sessionId;
        _log.Error($"Turn calculation error for session {sessionId}: {message}", innerException);
    }
} 