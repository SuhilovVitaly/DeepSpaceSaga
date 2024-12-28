namespace DeepSpaceSaga.Common.Infrastructure.Events;

public interface IGameActionEvents: IEnumerable<GameActionEvent>
{
    IGameActionEvents Clone();
}
