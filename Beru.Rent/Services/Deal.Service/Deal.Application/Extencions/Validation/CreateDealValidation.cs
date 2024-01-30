using Deal.Dto.Booking;
using FluentValidation;

namespace Deal.Application.Extencions.Validation;

public class CreateDealValidation : AbstractValidator<CreateDealRequestDto>
{
    public CreateDealValidation()
    {
        
    }
}