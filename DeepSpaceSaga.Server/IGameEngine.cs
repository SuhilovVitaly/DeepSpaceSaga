namespace DeepSpaceSaga.Server;

public interface IGameEngine
{
    event Action? OnTickExecute;
    event Action? OnTurnExecute;
}
