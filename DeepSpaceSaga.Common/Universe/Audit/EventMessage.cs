namespace DeepSpaceSaga.Common.Universe.Audit;

public class EventMessage
{
    public int Id { get; set; }
    public string Text { get; set; }
    public EventType Type { get; set; }
}
