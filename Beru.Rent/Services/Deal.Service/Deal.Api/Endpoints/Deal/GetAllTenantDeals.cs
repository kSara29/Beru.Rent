using Common;
using Deal.Application.Contracts.Deal;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;


public class GetAllTenantDeals(IDealService _service): Endpoint<GetDealPagesRequestDto,ResponseModel<GetDealPagesDto<GetDealResponseDto>>>
{
    public override void Configure()
    {
        Get("api/booking/GetAllTenantDeals/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDealPagesRequestDto dto, CancellationToken ct)
    {
        var results = await _service.GetAllTenantDealsAsync(dto);
        await SendAsync(results, cancellation: ct);
    }
}