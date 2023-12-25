using Microsoft.AspNetCore.Identity;

namespace User.Domain.Models;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Iin { get; set; }
    public Image? UserAvatar { get; set; }
}