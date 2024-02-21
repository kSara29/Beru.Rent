using User.Application.Contracts;

namespace User.Application.Validation;

public class ValidationHandler (IUserRepository repository): IUserValidator
{
    public async Task<bool> FindUserByPhoneNumberAsync(string phone)
    {
        return await repository.GetUserByPhoneAsync(phone);
    }

    public async Task<Domain.Models.User?> FindUserByEmailNumberAsync(string mail)
    {
        return await repository.GetUserByMailAsync(mail);
    }

    public async Task<Domain.Models.User?> FindUserByUserNameAsync(string userName)
    {
        return await repository.GetUserByUserNameAsync(userName);
    }
}