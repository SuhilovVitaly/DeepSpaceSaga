namespace DeepSpaceSaga.Common.Extensions;

public static class ModuleExtensions
{
    public static double GetWorkProgressPercentage(this IModule module)
    {
        if (module.ReloadTime <= 0)
        {
            throw new ArgumentException("Total time must be greater than zero.", nameof(module.ReloadTime));
        }

        if (module.Reloading < 0 || module.Reloading > module.ReloadTime)
        {
            return 100;
        }

        double percentage = (module.Reloading / module.ReloadTime) * 100;

        return Math.Round(percentage, 2);
    }
}
