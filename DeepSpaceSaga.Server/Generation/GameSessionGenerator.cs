﻿namespace DeepSpaceSaga.Server.Generation;

internal class GameSessionGenerator
{
    public static GameSession ProduceSession(GenerationTool generationTool, int sessionId = -1)
    {
        if (sessionId == -1)
        {
            var session = EmptySession(generationTool);
            session.Id = sessionId;
            return session;
        }

        throw new NotImplementedException();
    }

    private static GameSession EmptySession(GenerationTool generationTool)
    {
        var result = new GameSession(CelestialMapGenerator.GenerateEmptyBase(generationTool), new GameSessionsSettings())
        {
            Id = generationTool.GetId()
        };

        return result;
    }
}
