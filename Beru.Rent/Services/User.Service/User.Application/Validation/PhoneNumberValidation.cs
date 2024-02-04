using Common;
using Microsoft.AspNetCore.Identity;
using User.Application.Contracts;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Application.Extencions.Validation;

public class PhoneNumberValidation (IUserRepository repository, CreateUserDto userDto): IUserValidator
{
    public async Task<IdentityResult> ValidateAsync(string phone)
    {
        var existingUser = repository.GetUserByPhoneAsync(phone);
        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Description = "Номер телефона уже зарегистрирован."
            });
        }
        return IdentityResult.Success;
    }

    public async Task<bool> FindUserByPhoneNumberAsync(string phone)
    {
        return await repository.GetUserByPhoneAsync(phone);
    }

    public Task<string> GetMail()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserName()
    {
        throw new NotImplementedException();
    }
}