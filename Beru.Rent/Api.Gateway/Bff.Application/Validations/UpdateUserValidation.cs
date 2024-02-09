using FluentValidation;
using User.Dto.RequestDto;

namespace Bff.Application.Validations;

public class UpdateUserValidation: AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidation()
    {
        RuleFor(u => u).NotNull().WithMessage("Внутренняя ошибка");
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.LastName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.UserName).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.Iin).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.Mail).NotEmpty().WithMessage("Поле обязательно для заполнения.");
        RuleFor(u => u.Phone).NotEmpty().WithMessage("Поле обязательно для заполнения.");
    }
}