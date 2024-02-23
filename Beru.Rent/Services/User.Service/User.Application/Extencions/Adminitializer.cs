using Microsoft.AspNetCore.Identity;

namespace User.Application.Extencions;

public class Adminitializer
{
    public static async Task SeedAdminUserAsync(RoleManager<IdentityRole> roleManager, UserManager<Domain.Models.User> userManager)
    {
        var users = new List<Domain.Models.User>
        {
            new()
            {
                Id = "ecab5681-aa11-4f85-b5d5-72dd1705d767",
                Email = "admin@admin.admin",
                FirstName = "admin",
                LastName = "admin",
                Iin = "000000000",
                UserName = "admin",
                EmailConfirmed = true
            },
            new()
            {
                Id = "f547056b-930a-488d-84bd-70b922138fb9",
                Email = "Alex@alex.com",
                FirstName = "Alex",
                LastName = "Alex",
                Iin = "000000000",
                UserName = "Alex",
                EmailConfirmed = true
            },
            new()
            {
                Id = "8942be2b-210f-4d49-9331-5c3c47eb9402",
                Email = "Lana@alex.com",
                FirstName = "Lana",
                LastName = "Lana",
                Iin = "000000000",
                UserName = "Foxdom",
                EmailConfirmed = true
            },
            new()
            {
                Id = "c05263fc-e4f2-44b0-a18f-2bd0bb40aa8f",
                Email = "Evgeny@evgeny.com",
                FirstName = "Evgeny",
                LastName = "Evgeny",
                Iin = "000000000",
                UserName = "Evgeny",
                EmailConfirmed = true
            },
            new()
            {
                Id = "200aa31e-b533-4e66-99ff-f2c637109e72",
                Email = "Sara@sara.com",
                FirstName = "Sara",
                LastName = "Sara",
                Iin = "000000000",
                UserName = "Sara",
                EmailConfirmed = true
            }
        };
        
  
        var roles = new [] { "admin", "user" };
        
        foreach (var role in roles)
        {
            if (await roleManager.FindByNameAsync(role) is null)
                await roleManager.CreateAsync(new IdentityRole(role));
        }
        
        foreach (var user in users)
        {
            if (user.UserName == "admin")
                await CreateUsers(userManager, user, "admin");

            else
                await CreateUsers(userManager, user, "user");
        }
    }

    static async Task CreateUsers
        (UserManager<Domain.Models.User> userManager, 
            Domain.Models.User user, string role)
    {
        if (await userManager.FindByNameAsync(user.Email) == null)
        {
            var result = await userManager.CreateAsync(user, "Qwerty123@");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, role);
        }
    }
}