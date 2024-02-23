using Microsoft.AspNetCore.Identity;

namespace User.Application.Extencions;

public class Adminitializer
{
    public static async Task SeedAdminUserAsync(RoleManager<IdentityRole> roleManager, UserManager<Domain.Models.User> userManager)
    {
        var admin = new Domain.Models.User
        {
            Email = "admin@admin.admin",
            FirstName = "admin",
            LastName = "admin",
            Iin = "000000000",
            UserName = "admin"
        };
  
        var roles = new [] { "admin", "user" };
        
        foreach (var role in roles)
        {
            if (await roleManager.FindByNameAsync(role) is null)
                await roleManager.CreateAsync(new IdentityRole(role));
        }
        if (await userManager.FindByNameAsync(admin.Email) == null)
        {
            var result = await userManager.CreateAsync(admin, "Qwerty123@");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, roles[0]);
        }
    }
}