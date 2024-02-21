using Common;
using Microsoft.Extensions.Logging;
using User.Application.Contracts;
using User.Application.Mapper;
using User.Application.Validation;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Application.Services;

public class UserService(IUserRepository userRepository, 
    UpdateUserValidation updateUserValidation, ILogger<UserService> logger) : IUserService
{
    public async Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password)
    {
        var user = await userRepository.CreateUserAsync(model.ToUser()!, password);
        
        logger.LogInformation("Пользователь создан {@user}", user);
        return user;
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto model)
    {
        Domain.Models.User? user = await userRepository.GetUserByIdAsync(model.UserId);
        if (user is null)
        {
            //TODO: корректно вернуть ответ
            throw new NullReferenceException();
        }
        user = user.UpdateUser(model);
        
        var result = await updateUserValidation.ValidateAsync(user.ToUpdateUserDto()!);
        if (!result.IsValid && result.Errors.Count > 0)
        {
            var responseFailed = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError>());
            foreach (var validationFailure in result.Errors)
            {
                responseFailed.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }
            return responseFailed;
        }
        
        await userRepository.UpdateUserAsync(user);
        return new ResponseModel<UserDtoResponce>
        {
            Status = ResponseStatus.Success,
            Data = user.ToUserDtoResponse(),
            Errors = null
        };
    }

    public async Task<UserDtoResponce> GetUserByIdAsync(string userId)
    {
        Domain.Models.User? user = await userRepository.GetUserByIdAsync(userId);
        
        logger.LogInformation("Вернули пользователя по Id {@response}", user);
        return user.ToUserDtoResponse();
    }
    
    public async Task<UserDtoResponce> GetUserByMailAsync(string mail)
    {
        var user = await userRepository.GetUserByMailAsync(mail);
        
        logger.LogInformation("Вернули пользователя по почте {@response}", user);
        return user.ToUserDtoResponse();
    }
    
    public async Task<UserDtoResponce> GetUserByNameAsync(string userName)
    {
        var user = await userRepository.GetUserByUserNameAsync(userName);
        
        logger.LogInformation("Вернули пользователя по имени {@response}", user);
        return user.ToUserDtoResponse();
    }

    public async Task<UserDtoResponce?> DeleteUserAsync(string userId)
    {
        var user = await userRepository.GetUserByIdAsync(userId);
        if (user is not null)
        {
            var result = await userRepository.DeleteUserAsync(user);
            
            logger.LogInformation("Удалили пользователя {@response}", user);
            return result.ToUserDtoResponse();
        }
        return null;
    }
}