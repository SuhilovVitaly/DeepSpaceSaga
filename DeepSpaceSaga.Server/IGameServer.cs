namespace DeepSpaceSaga.Server;

public interface IGameServer
{
    void ResumeSession();
    void PauseSession();
    void SessionInitialization(int sessionId = -1);
    GameSession GetSession();
    void AddCommand(Command command);

    void SetGameSpeed(int speed);
}
