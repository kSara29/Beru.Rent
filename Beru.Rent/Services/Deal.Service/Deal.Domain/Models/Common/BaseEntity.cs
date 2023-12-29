namespace Deal.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; set; }
    
}