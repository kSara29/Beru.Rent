using User.Application.DTO;

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
                IIN = model.IIN,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                UserName = model.UserName
            };
    }
}