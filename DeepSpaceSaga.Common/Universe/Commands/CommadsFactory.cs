namespace DeepSpaceSaga.Common.Universe.Commands;

public class CommandsFactory
{
    // Creates a command based on the specified type
    public static ICommand CreateCommand(GenerationTool generationTool, CommandTypes commandType, IModule module, ICelestialObject targetObject, ICelestialObject sourceObject)
    {
        var command = BaseCommand(generationTool, commandType, module, targetObject, sourceObject);

        // Set default properties based on command type
        switch (commandType)
        {
            case CommandTypes.Fire:
            case CommandTypes.Shot:
                command.IsOneTimeCommand = true;
                command.IsUnique = false;
                break;
            case CommandTypes.Scanning:
            case CommandTypes.PreScanCelestialObject:
                command.IsOneTimeCommand = false;
                command.IsUnique = true;
                break;
            case CommandTypes.MoveForward:
            case CommandTypes.RotateToTarget:
            case CommandTypes.SyncSpeedWithTarget:
            case CommandTypes.SyncDirectionWithTarget:
                command.IsOneTimeCommand = false;
                command.IsUnique = true;
                break;
            case CommandTypes.MiningOperationsresult:
                command.Category = CommandCategory.Mining;
                break;
            default:
                command.IsOneTimeCommand = true;
                command.IsUnique = true;
                break;
        }
        return command;
    }
    
    private static ICommand BaseCommand(GenerationTool generationTool, CommandTypes commandType, IModule module, ICelestialObject targetObject, ICelestialObject sourceObject)
    {
        var command = new Command
        {
            Id = generationTool.GetId(),
            Type = commandType,
            Status = CommandStatus.PreProcess,
            CelestialObjectId = sourceObject.Id,
            TargetCelestialObjectId = targetObject.Id,
            ModuleId = module.Id,
        };

        return command;
    }
}

