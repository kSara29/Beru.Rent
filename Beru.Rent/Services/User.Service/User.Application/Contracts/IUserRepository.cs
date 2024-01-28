namespace User.Application.Contracts;

public interface IUserRepository
{
    Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model, string password);
    Task<Domain.Models.User> GetUserByIdAsync(string id);
    Task<Domain.Models.User> GetUserByMailAsync(string mail);
    Task<Domain.Models.User> GetUserByNameAsync(string userName);
    Task<Domain.Models.User> UpdateUserAsync(Domain.Models.User user);
    Task<Domain.Models.User> DeleteUserAsync(string id);
}