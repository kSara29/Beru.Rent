using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class GetDeal(IDealService _service) : Endpoint<GetDealRequestDto, ResponseModel<GetDealResponseDto>>
{
    public override void Configure()
    {
        Get("bff/deal/GetDeal/{DealId}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetDealRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GetDealAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}