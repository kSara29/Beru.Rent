using Common;
using Deal.Application.Contracts.Deal;
using Deal.Application.Services;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetAllDeals(IDealService _service): Endpoint<GetDealPagesRequestDto,ResponseModel<GetDealPagesDto<GetDealResponseDto>>>
{
    public override void Configure()
    {
        Get("api/deal/GetAllDeals/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDealPagesRequestDto dto, CancellationToken ct)
    {
        var results = await _service.GetAllDealsAsync(dto);
        await SendAsync(results, cancellation: ct);
    }
}