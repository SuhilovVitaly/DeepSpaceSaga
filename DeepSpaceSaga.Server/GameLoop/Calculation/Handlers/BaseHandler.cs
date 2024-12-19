namespace DeepSpaceSaga.Server.GameLoop.TurnCalculation.Handlers;

public abstract class BaseHandler
{
    protected readonly ILog _log;

    protected BaseHandler()
    {
        _log = LogManager.GetLogger(GetType());
    }

    protected void LogHandlerStart(string handlerName, string sessionId)
    {
        _log.Debug($"Starting {handlerName} for session {sessionId}");
    }

    protected void LogHandlerComplete(string handlerName, string sessionId)
    {
        _log.Debug($"Completed {handlerName} for session {sessionId}");
    }
} 