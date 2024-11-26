namespace DeepSpaceSaga.Server;

public interface IGameServer
{
    void ResumeSession();
    void PauseSession();
    void SessionInitialization(int sessionId = -1);
    GameSession GetSession();
    void EventsCalculation();
    void LocationCalculation();
    Task AddCommand(Command command);
}
