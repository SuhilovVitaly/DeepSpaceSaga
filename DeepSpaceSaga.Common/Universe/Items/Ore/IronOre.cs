namespace DeepSpaceSaga.Common.Universe.Items.Ore;

[Serializable]
public class IronOre: AbstractItem, ICoreItem
{
    public IronOre(int volume = 1)
    {
        Volume = volume;
        Category = Category.Ore;
        Image = "Ore.Iron";
    }
}
