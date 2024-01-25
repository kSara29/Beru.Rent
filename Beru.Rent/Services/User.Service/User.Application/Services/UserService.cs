using User.Application.Contracts;
using User.Application.Mapper;
using User.Dto;

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

    public async Task<UserDto> GetUserByIdAsync(string userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return user.ToUserDto();
    }
    
    public async Task<UserDto> GetUserByMailAsync(string mail)
    {
        var user = await _userRepository.GetUserByMailAsync(mail);
        return user.ToUserDto();
    }
    
    public async Task<UserDto> GetUserByNameAsync(string userName)
    {
        var user = await _userRepository.GetUserByNameAsync(userName);
        return user.ToUserDto();
    }

    public async Task<UserDto> DeleteUserAsync(string userId)
    {
        var result = await _userRepository.DeleteUserAsync(userId);
        return result.ToUserDto();
    }
}