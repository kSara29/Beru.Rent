namespace User.Domain.Models;

public class Image
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}