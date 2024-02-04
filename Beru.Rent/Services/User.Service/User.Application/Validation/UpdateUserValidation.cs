using System.Text.RegularExpressions;
using FluentValidation;

namespace User.Application.Validation;

public class UpdateUserValidation: AbstractValidator<Domain.Models.User>
{
    public UpdateUserValidation()
    {
        RuleFor(u => u.Email)
            .EmailAddress().WithMessage("Некорректный адрес почты.");
        RuleFor(u => u.PhoneNumber)
            .Matches(new Regex(@"^\(?([0-9]{10})$")).WithMessage("Не корректный ввод номера");
    }
}