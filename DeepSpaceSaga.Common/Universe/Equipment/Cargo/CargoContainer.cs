﻿namespace DeepSpaceSaga.Common.Universe.Equipment.Mining;

[Serializable]
public class CargoContainer : AbstractModule, IModule, ICargoContainer
{
    private static readonly ILog _log = LogManager.GetLogger(typeof(MiningLaser));
    public double Power { get; set; }
    public double Capacity { get; set; } = 0;
    public double MaxCapacity { get; set; } = 0;
    public double ActivationCost { get; set; } = 0;
    [JsonProperty]
    public List<ICoreItem> Items  { get; private set; } = new List<ICoreItem>();    

    public Command Show()
    {
        _log.Info($"Show command for module {Id}");

        var command = new Command
        {
            Category = CommandCategory.CargoOperations,
            Type = CommandTypes.CargoOperationsShow,
            CelestialObjectId = OwnerId,
            TargetCelestialObjectId = 0,
            ModuleId = Id
        };

        _log.Info($"Created command for module {Id}");

        return command;
    }
    public void AddItem(ICoreItem item)
    {
        Items.Add(item);
    }

    public void AddItems(List<ICoreItem> items)
    {
        Items.AddRange(items);
    }

    public void RemoveItem(ICoreItem item)
    {
        var itemToRemove = Items.FirstOrDefault(x => x.Id == item.Id);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
        }
    }

    public ICoreItem GetItemById(int itemId)
    {
        var item = Items.FirstOrDefault(x => x.Id == itemId);
        if (item != null)
        {
            return item;
        }

        throw new Exception($"Item with id {itemId} not found");
    }
}
