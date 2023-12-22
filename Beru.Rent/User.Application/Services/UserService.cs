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

    public async Task<Domain.Models.User> UpdateUserAsync(UpdateUserDto model)
    {
        var user = await _userRepository.GetUserByIdAsync(model.UserId);
        if (user is null) return null;
        
        user.UpdateUser(model);
        await _userRepository.UpdateUserAsync(user);

        return user;
    }
}