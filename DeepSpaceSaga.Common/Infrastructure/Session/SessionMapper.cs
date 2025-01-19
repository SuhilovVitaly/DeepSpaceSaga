using LanguageExt;

namespace DeepSpaceSaga.Common.Infrastructure.Session;

public static class SessionMapper
{
    public static GameSessionDTO ToSessionDto(this GameSession session)
    {
        return new GameSessionDTO { 
            CelestialMap = session.SpaceMap.Copy(),
            Logbook = session.Logbook.Copy(),
            State = session.State.Copy(),
            Events = session.Events.Copy(),
        };
    }
}
