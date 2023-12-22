using Microsoft.AspNetCore.Identity;

namespace User.Application.Extencions;

public class Adminitializer
{
    public static async Task SeedAdminUserAsync(RoleManager<IdentityRole> roleManager, UserManager<Domain.Models.User> userManager)
    {
        Domain.Models.User admin = new Domain.Models.User
        {
            Email = "admin@admin.admin",
            FirstName = "admin",
            LastName = "admin",
            IIN = "000000000",
            UserName = "admin"
        };
  
        var roles = new [] { "admin", "user" };
        
        foreach (var role in roles)
        {
            if (roleManager.FindByNameAsync(role) is null)
                roleManager.CreateAsync(new IdentityRole(role));
        }
        if (userManager.FindByNameAsync(admin.Email) == null)
        {
            IdentityResult result = await userManager.CreateAsync(admin, "Qwerty123@");
            if (result.Succeeded)
                userManager.AddToRoleAsync(admin, roles[0]);
        }

    }
}