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

    public async Task<UserDtoResponce> GetUserByIdAsync(string userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return user.ToUserDto();
    }
    
    public async Task<UserDtoResponce> GetUserByMailAsync(string mail)
    {
        var user = await _userRepository.GetUserByMailAsync(mail);
        return user.ToUserDto();
    }
    
    public async Task<UserDtoResponce> GetUserByNameAsync(string userName)
    {
        var user = await _userRepository.GetUserByNameAsync(userName);
        return user.ToUserDto();
    }

    public async Task<UserDtoResponce?> DeleteUserAsync(string userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user is not null)
        {
            var result = await _userRepository.DeleteUserAsync(user);
            return result.ToUserDto();
        }
        return null;
    }
}