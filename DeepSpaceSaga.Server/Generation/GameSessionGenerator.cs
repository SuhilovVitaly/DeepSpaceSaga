namespace DeepSpaceSaga.Server.Generation;

internal class GameSessionGenerator
{
    public static GameSession ProduceSession(int sessionId = -1)
    {
        if (sessionId == -1)
        {
            var session = EmptySession();
            session.Id = sessionId;
            return session;
        }

        throw new NotImplementedException();
    }

    private static GameSession EmptySession()
    {
        var result = new GameSession(CelestialMapGenerator.GenerateEmptyBase(), new GameSessionsSettings())
        {
            Id = new GenerationTool().GetId(),
            IsRunning = false
        };

        return result;
    }
}
