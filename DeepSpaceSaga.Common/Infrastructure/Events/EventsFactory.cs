namespace DeepSpaceSaga.Common.Infrastructure.Events;

public class EventsFactory
{
    public static GameActionEvent CreateEvent(IGenerationTool generationTool, ICommand command, IModule? module, ICelestialObject? targetObject, ICelestialObject? sourceObject, ICelestialObject? createdObject = null)
    {
        var commandInternal = command.Copy() as ICommand;

        return new GameActionEvent
        {
            Id = generationTool.GetId(),
            CelestialObjectId = sourceObject?.Id,
            ModuleId = module?.Id,
            TargetObjectId = targetObject?.Id,
            TriggerCommand = commandInternal
        };
    }
}
