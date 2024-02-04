using Common;
using User.Dto.ResponseDto;

namespace User.Application.Contracts;

public interface IUserValidator
{
    Task<bool> FindUserByPhoneNumberAsync(string phone);
    Task<string> GetMail();
    Task<string> GetUserName();
}