namespace DeepSpaceSaga.Common.Universe.Equipment.Scanner;

public interface IScanner: IModule
{
    double ScanRange { get; set; }
    double Power { get; set; }
    bool IsEnabled { get; set; }
}