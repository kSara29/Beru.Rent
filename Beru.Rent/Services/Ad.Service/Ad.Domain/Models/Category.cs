

namespace Ad.Domain.Models;

public class Category:Entity
{
    public required string Title { get; set; }
    public Guid? ParentId { get; set; }
    
}