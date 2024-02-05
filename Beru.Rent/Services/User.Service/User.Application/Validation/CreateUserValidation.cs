using System.Text.RegularExpressions;
using FluentValidation;
using User.Dto.RequestDto;

namespace User.Application.Validation;

public class CreateUserValidation : AbstractValidator<CreateUserDto>
{
    public CreateUserValidation()
    {
        RuleFor(u => u.Mail)
            .EmailAddress().WithMessage("Некорректный адрес почты.");
        RuleFor(u => u.Phone)
            .Matches(new Regex(@"^\(?([0-9]{10})$")).WithMessage("Не корректный ввод номера");
        RuleFor(u => u.Password)
            .Equal(u => u.ConfirmPassword).WithMessage("Пароли не совпадают.");
    }
}