using Common;
using Deal.Application.Contracts.Deal;
using Deal.Application.Extencions.Validation;
using Deal.Dto.Booking;
using FastEndpoints;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Deal.Api.Endpoints;

public class CreateDeal(IDealService service) : Endpoint<CreateDealRequestDto, ResponseModel<CreateDealResponseDto>>
{
    public override void Configure()
    {
        Post("/api/deal/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateDealRequestDto request, CancellationToken ct)
    {
        CreateDealValidation createDealValidation = new CreateDealValidation();
        ValidationResult valresult = createDealValidation.Validate(request);
        if (valresult.IsValid && valresult.Errors.Count > 0)
        {
            var responce = ResponseModel<CreateDealResponseDto>.CreateFailed(new List<ResponseError?>());
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
            var results = await service.CreateDealAsync(request);
            var res = ResponseModel<CreateDealResponseDto>.CreateSuccess(results);
            await SendAsync(res, cancellation: ct);
        }
    }
}