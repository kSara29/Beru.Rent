using System.Text.RegularExpressions;
using FluentValidation;
using User.Dto;
using User.Dto.RequestDto;

namespace User.Application.Extencions.Validation;

public class CreateUserValidation : AbstractValidator<CreateUserDto>
{
    public CreateUserValidation()
    {
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.LastName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.UserName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.Iin).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.Mail).NotEmpty().WithMessage("Поле обязательно для заполнения.")
            .EmailAddress().WithMessage("Некорректный адрес почты.");
        RuleFor(u => u.Phone)
            .NotEmpty().WithMessage("Поле обязательно для заполнения.")
            .Matches(new Regex(@"^\(?([0-9]{10})$"))
            .WithMessage("Не корректный ввод номера");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Поле обязательно для заполнения.")
            .Equal(u => u.ConfirmPassword).WithMessage("Пароли не совпадают.");
        
    }
}