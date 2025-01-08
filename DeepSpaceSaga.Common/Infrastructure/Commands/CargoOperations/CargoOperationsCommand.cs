namespace DeepSpaceSaga.Common.Infrastructure.Commands.CargoOperations;

public class CargoOperationsCommand: Command, ICommand
{
    public int InputModuleId { get; set; }

    public int InputItemId { get; set; }
}
