using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class CloseDeal(IDealService _service) : Endpoint<CloseDealRequestDto, ResponseModel<CloseDealResponseDto>>
{
    public override void Configure()
    {
        Get("/bff/deal/close");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CloseDealRequestDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.CloseDealAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}