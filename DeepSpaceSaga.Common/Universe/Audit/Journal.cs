namespace DeepSpaceSaga.Common.Universe.Audit;

public class Journal(IEnumerable<EventMessage> objects) : List<EventMessage>(objects)
{

    public List<EventMessage> GetJournalContent()
    {
        return this.ToList(); ;
    }

    public void ClearJournal()
    {
        Clear();
    }
}
