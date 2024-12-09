namespace Task_FullStack_EntityFramework.Entities;

public class Comment
{
    public  Guid Id { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public RequestItem RequestItem { get; set; }
    public Guid RequestItemId { get; set; }

}
