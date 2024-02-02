using Bff.Application.Contracts;
using Common;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Bff.Api.Endpoints.DealService.Deal;

public class GetAllDeals(IDealService _service) : Endpoint<RequestByUserId, ResponseModel<List<GetAllDealsResponseDto>>>
{
    public override void Configure()
    {
        Get("/bff/deal/GetAllDeals/{Id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (RequestByUserId? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await _service.GetAllDealsAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}