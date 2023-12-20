using Microsoft.AspNetCore.Identity;
using User.Domain.Models.Common;

namespace User.Domain.Models;

public class User: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IIN { get; set; }
    public Image UserAvatar { get; set; }
}