using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Task_FullStack_EntityFramework.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Nick { get; set; }
    public string Email { get; set; }

    public List<RequestItem> RequestItems { get; set; } = new List<RequestItem>();
}
