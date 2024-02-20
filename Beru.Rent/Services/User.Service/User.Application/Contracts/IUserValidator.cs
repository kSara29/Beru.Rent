
namespace User.Application.Contracts;

public interface IUserValidator
{
    Task<bool> FindUserByPhoneNumberAsync(string phone);
    Task<Domain.Models.User?> FindUserByEmailNumberAsync(string mail);
    Task<Domain.Models.User?> FindUserByUserNameAsync(string userName);

}