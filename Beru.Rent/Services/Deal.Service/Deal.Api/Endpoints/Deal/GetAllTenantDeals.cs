using Common;
using Deal.Application.Contracts.Deal;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;


public class GetAllTenantDeals(IDealService _service): Endpoint<RequestByUserId,ResponseModel<List<GetAllDealsResponseDto>>>
{
    public override void Configure()
    {
        Get("api/booking/GetAllTenantDeals/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestByUserId Id, CancellationToken ct)
    {
        var results = await _service.GetAllTenantDealsAsync(Id);
        await SendAsync(results, cancellation: ct);
    }
}