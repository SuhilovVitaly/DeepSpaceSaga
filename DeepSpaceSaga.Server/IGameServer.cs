namespace DeepSpaceSaga.Server;

public interface IGameServer
{
    void ResumeSession();
    void PauseSession();
    void SessionInitialization();
    GameSessionData GetSession();
    void EventsCalculation();
    void LocationCalculation();
}
