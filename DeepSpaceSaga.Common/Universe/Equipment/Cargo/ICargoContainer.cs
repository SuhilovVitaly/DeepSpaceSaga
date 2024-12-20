using DeepSpaceSaga.Common.Universe.Items;

namespace DeepSpaceSaga.Common.Universe.Equipment.Mining;

public interface ICargoContainer : IModule
{
    double Power { get; set; }
    double Capacity { get; set; }
    double MaxCapacity { get; set; }
    Command Show();
    IEnumerable<ICoreItem> Items();
}
