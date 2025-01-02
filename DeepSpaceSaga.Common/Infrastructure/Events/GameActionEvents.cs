namespace DeepSpaceSaga.Common.Infrastructure.Events;

public class GameActionEvents(IEnumerable<GameActionEvent> objects) : List<GameActionEvent>(objects) , IGameActionEvents
{
    public IGameActionEvents Clone()
    {
        return new GameActionEvents(objects.Copy());
    }
}
