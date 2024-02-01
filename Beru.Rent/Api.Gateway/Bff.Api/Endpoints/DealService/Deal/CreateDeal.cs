using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class CreateDeal(IDealService _service) : Endpoint<CreateDealRequestDto, ResponseModel<CreateDealResponseDto>>
{
    public override void Configure()
    {
        Post("/bff/deal/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateDealRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.CreateDealAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}