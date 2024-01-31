using Deal.Dto.Booking;
using FluentValidation;

namespace Deal.Application.Extencions.Validation;

public class CreateBookingValidation: AbstractValidator<CreateBookingRequestDto>
{
    public CreateBookingValidation()
    {
        RuleFor(u => u.Dbeg).NotEmpty().WithMessage("Дата начала обязательна должна быть выбрана");
        RuleFor(u => u.Dend).NotEmpty().WithMessage("Дата конца обязательна должна быть выбрана");
    }
}