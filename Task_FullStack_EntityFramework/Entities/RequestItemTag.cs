namespace Task_FullStack_EntityFramework.Entities;

public class RequestItemTag
{
    public RequestItem RequestItem { get; set; }
    public Guid RequestItemId { get; set; }

    public Tag Tag { get; set; }
    public Guid TagId { get; set; }

    public DateTime PublicationDate { get; set; }
}
