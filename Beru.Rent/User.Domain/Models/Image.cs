namespace User.Domain.Models;

public class Image
{
    public string UserId { get; set; }
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public User User { get; set; }
    
}