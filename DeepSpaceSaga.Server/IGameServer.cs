﻿namespace DeepSpaceSaga.Server;

public interface IGameServer
{
    event Action<GameSession>? OnTickExecute;
    event Action<GameSession>? OnTurnExecute;
    void ResumeSession();
    void PauseSession();
    Task SessionInitialization(int sessionId = -1);
    GameSession GetSession();
    Task AddCommand(ICommand command);
    void SetGameSpeed(int speed);
    void QuickSave();
    void QuickLoad();
    void Load(string saveName);
}
