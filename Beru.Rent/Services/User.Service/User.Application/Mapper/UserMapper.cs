using User.Dto;

namespace User.Application.Mapper;

public static class UserMapper
{
    public static Domain.Models.User? ToUser(this CreateUserDto? model)
    {
        return model is null
            ? null
            : new Domain.Models.User
            {
                FirstName = model.FirstName,
                Email = model.Mail,
                Iin = model.Iin,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                UserName = model.UserName
            };
    }
    
    public static UserDto? ToUserDto(this Domain.Models.User? model)
    {
        return model is null
            ? null
            : new UserDto
            {
                UserId = model.Id,
                FirstName = model.FirstName,
                Mail = model.Email,
                Iin = model.Iin,
                LastName = model.LastName,
                Phone = model.PhoneNumber,
                UserName = model.UserName
            };
    }

    public static Domain.Models.User UpdateUser(this Domain.Models.User user, UpdateUserDto model)
    {
        if (!string.IsNullOrWhiteSpace(model.FirstName))
            user.FirstName = model.FirstName;

        if (!string.IsNullOrWhiteSpace(model.Mail))
            user.Email = model.Mail;
        
        if (!string.IsNullOrWhiteSpace(model.UserName))
            user.UserName = model.UserName;

        if (!string.IsNullOrWhiteSpace(model.LastName))
            user.LastName = model.LastName;

        if (!string.IsNullOrWhiteSpace(model.Iin))
            user.Iin = model.Iin;

        return user;
    }
}