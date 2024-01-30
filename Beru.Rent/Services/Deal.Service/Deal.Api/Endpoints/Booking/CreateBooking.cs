using System.ComponentModel.DataAnnotations;
using Common;
using Deal.Application.Contracts.Booking;
using Deal.Application.Extencions.Validation;
using Deal.Dto.Booking;
using FastEndpoints;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Deal.Api.Endpoints;

public class CreateBooking(IBookingService service) : Endpoint<CreateBookingRequestDto, ResponseModel<BoolResponseDto>>
{
    public override void Configure()
    {
        Post("/api/booking/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync
        (CreateBookingRequestDto model, CancellationToken ct)
    {
        CreateBookingValidation createBookingValidation = new CreateBookingValidation();
        ValidationResult valresult = createBookingValidation.Validate(model);
        if (!valresult.IsValid && valresult.Errors.Count >0)
        {
            var responce = ResponseModel<BoolResponseDto>.CreateFailed(new List<ResponseError?>());
            foreach (var validationFailure in valresult.Errors)
            {
                responce.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }

            await SendAsync(responce, cancellation: ct);
        }
        else
        {
            var results = await service.CreateBookingAsync(model);
            var res = ResponseModel<BoolResponseDto>.CreateSuccess(results);
            await SendAsync(res, cancellation: ct);
        }
        
    }
}