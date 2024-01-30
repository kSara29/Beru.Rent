using User.Dto;
using User.Dto.RequestDto;

namespace User.Application.Extencions.Validation;

public static class UserValidation
{
    public static List<string>? CreateUserValidate(this CreateUserDto model)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(model.FirstName)) errors.Add(nameof(model.FirstName));
        if (string.IsNullOrWhiteSpace(model.Password)) errors.Add(nameof(model.Password));
        if (string.IsNullOrWhiteSpace(model.Mail)) errors.Add(nameof(model.Mail));
        if (string.IsNullOrWhiteSpace(model.Phone)) errors.Add(nameof(model.Phone));
        if (string.IsNullOrWhiteSpace(model.LastName)) errors.Add(nameof(model.LastName));
        if (string.IsNullOrWhiteSpace(model.UserName)) errors.Add(nameof(model.UserName));
        if (string.IsNullOrWhiteSpace(model.Iin)) errors.Add(nameof(model.Iin));
        return errors;
    }
    
    public static List<string>? UpdateUserValidate(this UpdateUserDto? model)
    {
        if (model is null)
            return null;
        
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(model.UserId)) errors.Add(nameof(model.UserId));
        if (string.IsNullOrWhiteSpace(model.FirstName)) errors.Add(nameof(model.FirstName));
        if (string.IsNullOrWhiteSpace(model.Mail)) errors.Add(nameof(model.Mail));
        if (string.IsNullOrWhiteSpace(model.Phone)) errors.Add(nameof(model.Phone));
        if (string.IsNullOrWhiteSpace(model.LastName)) errors.Add(nameof(model.LastName));
        if (string.IsNullOrWhiteSpace(model.UserName)) errors.Add(nameof(model.UserName));
        if (string.IsNullOrWhiteSpace(model.Iin)) errors.Add(nameof(model.Iin));
        return errors;
    }
}