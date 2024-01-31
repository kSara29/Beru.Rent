using Microsoft.AspNetCore.Identity;

namespace User.Application.Extencions.Validation;

public class PhoneNumberValidation: IUserValidator<Domain.Models.User>
{
    public async Task<IdentityResult> ValidateAsync(UserManager<Domain.Models.User> manager, Domain.Models.User user)
    {
        Domain.Models.User? existingUser = manager.Users
            .FirstOrDefault(u => u.PhoneNumber == user.PhoneNumber);
        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Description = "Номер телефона уже зарегистрирован."
            });
        }
        return IdentityResult.Success;
    }
}