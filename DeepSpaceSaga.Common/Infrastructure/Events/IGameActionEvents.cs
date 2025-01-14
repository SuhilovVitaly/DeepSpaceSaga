namespace DeepSpaceSaga.Common.Infrastructure.Events;

public interface IGameActionEvents: IEnumerable<IGameActionEvent>
{
    IGameActionEvents Clone();
}
