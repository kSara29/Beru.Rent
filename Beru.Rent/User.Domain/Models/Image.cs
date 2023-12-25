namespace User.Domain.Models;

public class Image
{
    public required string UserId { get; set; }
    public Guid Id { get; set; }
    public required string? ImagePath { get; set; }
    public User? User { get; set; }
    
}