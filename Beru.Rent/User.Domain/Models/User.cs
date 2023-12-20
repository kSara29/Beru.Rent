using Microsoft.AspNetCore.Identity;
using User.Domain.Models.Common;

namespace User.Domain.Models;

public class User: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IIN { get; set; }
    public string Mail { get; set; }
    public bool IsMailConfirm { get; set; }
    public string Phone { get; set; }
    public bool IsPhoneConfirm { get; set; }
    public Image UserAvatar { get; set; }
}