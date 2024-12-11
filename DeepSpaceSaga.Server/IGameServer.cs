namespace DeepSpaceSaga.Server;

public interface IGameServer
{
    void ResumeSession();
    void PauseSession();
    void SessionInitialization(int sessionId = -1);
    GameSession GetSession();
    Task AddCommand(Command command);

    void SetGameSpeed(int speed);
}
