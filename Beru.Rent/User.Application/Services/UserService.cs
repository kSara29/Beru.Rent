using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Mapper;

namespace User.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password)
    {
        var user = await _userRepository.CreateUserAsync(model.ToUser()!, password);
        return user;
    }
}