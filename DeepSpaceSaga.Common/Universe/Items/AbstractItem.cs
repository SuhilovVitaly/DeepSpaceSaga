namespace DeepSpaceSaga.Common.Universe.Items;

public class AbstractItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long OwnerId { get; set; }
    public Category Category { get; set; }
    public bool IsPacked { get; set; }
    public double Volume { get; set; } = 0;
}
