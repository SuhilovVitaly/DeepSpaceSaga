namespace DeepSpaceSaga.Common.Infrastructure.Events;

public class GameActionEvents(IEnumerable<IGameActionEvent> objects) : List<IGameActionEvent>(objects) , IGameActionEvents
{
    public IGameActionEvents Clone()
    {
        return new GameActionEvents(objects.Copy());
    }
}
