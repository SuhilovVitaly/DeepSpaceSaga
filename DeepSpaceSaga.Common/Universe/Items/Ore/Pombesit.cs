namespace DeepSpaceSaga.Common.Universe.Items.Ore;

public class Pombesit: AbstractItem, ICoreItem
{
    public Pombesit(int volume = 1)
    {
        Volume = volume;
        Category = Category.Ore;
        Image = "Ore.Pombesit";
    }
}
