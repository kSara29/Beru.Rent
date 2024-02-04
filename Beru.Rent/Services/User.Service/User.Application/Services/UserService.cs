using Common;
using User.Application.Contracts;
using User.Application.Mapper;
using User.Application.Validation;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Application.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password)
    {
        var user = await userRepository.CreateUserAsync(model.ToUser()!, password);
        return user;
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto model)
    {
        var user = await userRepository.GetUserByIdAsync(model.UserId);
        user = user.UpdateUser(model);

        var validation = new UpdateUserValidation();
        var result = validation.Validate(user);
        if (!result.IsValid && result.Errors.Count > 0)
        {
            var responseFailed = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
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
        // if (user is null) return null;
        // if (!string.IsNullOrWhiteSpace(model.FirstName) && user.FirstName != model.FirstName)
        //     user.FirstName = model.FirstName;
        // if (!string.IsNullOrWhiteSpace(model.LastName) && user.LastName != model.LastName)
        //     user.LastName = model.LastName;
        // if (!string.IsNullOrWhiteSpace(model.UserName) && user.UserName != model.UserName)
        //     user.UserName = model.UserName;
        // if (!string.IsNullOrWhiteSpace(model.Iin) && user.Iin != model.Iin)
        //     user.Iin = model.Iin;
        // if (!string.IsNullOrWhiteSpace(model.Mail) && user.Email != model.Mail)
        //     user.Email = model.Mail;
        // if (!string.IsNullOrWhiteSpace(model.Phone) && user.PhoneNumber != model.Phone)
        //     user.PhoneNumber = model.Phone;
        
        await userRepository.UpdateUserAsync(user);
        return new ResponseModel<UserDtoResponce>
        {
            Status = ResponseStatus.Success,
            Data = user.ToUserDto(),
            Errors = null
        };
    }

    public async Task<UserDtoResponce> GetUserByIdAsync(string userId)
    {
        var user = await userRepository.GetUserByIdAsync(userId);
        return user.ToUserDto();
    }
    
    public async Task<UserDtoResponce> GetUserByMailAsync(string mail)
    {
        var user = await userRepository.GetUserByMailAsync(mail);
        return user.ToUserDto();
    }
    
    public async Task<UserDtoResponce> GetUserByNameAsync(string userName)
    {
        var user = await userRepository.GetUserByNameAsync(userName);
        return user.ToUserDto();
    }

    public async Task<UserDtoResponce?> DeleteUserAsync(string userId)
    {
        var user = await userRepository.GetUserByIdAsync(userId);
        if (user is not null)
        {
            var result = await userRepository.DeleteUserAsync(user);
            return result.ToUserDto();
        }
        return null;
    }
}