namespace Task_FullStack_EntityFramework.Entities;

public class Tag
{
    public Guid Id { get; set; }

    public string Value { get; set; }
    public List<RequestItem> RequestItems { get; set; }
}
