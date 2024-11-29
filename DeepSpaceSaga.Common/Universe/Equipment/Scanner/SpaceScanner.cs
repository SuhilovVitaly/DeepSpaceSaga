namespace DeepSpaceSaga.Common.Universe.Equipment.Scanner;

public class SpaceScanner : AbstractModule, IModule, IScanner
{
    public Category Category { get; set; }
    public double ActivationCost { get; set; }
    public double ScanRange { get; set; }
    public double Power { get; set; }
    public bool IsEnabled { get; set; } = true;

    public SpaceScanner()
    {
        IsAutoRun = true;
    }
}
