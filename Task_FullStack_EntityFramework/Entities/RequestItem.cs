namespace Task_FullStack_EntityFramework.Entities;

public class RequestItem
{
    public Guid Id { get; set; }

    public Like Likes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public User Author { get; set; }
    public Guid AuthorId { get; set; }

    public List<Tag> Tags { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

}
