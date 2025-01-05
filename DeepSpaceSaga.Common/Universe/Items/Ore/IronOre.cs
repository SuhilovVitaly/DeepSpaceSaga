namespace DeepSpaceSaga.Common.Universe.Items.Ore;

public class IronOre: AbstractItem, ICoreItem
{
    public IronOre(int volume = 1)
    {
        Volume = volume;
        Category = Category.Ore;
        Image = "Ore.Iron";
    }
}
