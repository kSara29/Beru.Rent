using User.Application.Contracts;

namespace User.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model)
    {
        var user = await _userRepository.CreateUserAsync(model);
        return user;
    }
}