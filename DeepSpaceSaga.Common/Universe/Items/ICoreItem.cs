namespace DeepSpaceSaga.Common.Universe.Items;

public interface ICoreItem
{
    int Id { get; set; }
    string Name { get; set; }
    long OwnerId { get; set; }
    Category Category { get; set; }
    bool IsPacked { get; set; }
    double Volume { get; set; }
}
