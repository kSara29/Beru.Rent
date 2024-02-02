using Common;
using Deal.Application.Contracts.Deal;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetDeal(IDealService _service): Endpoint<GetDealRequestDto, ResponseModel<GetDealResponseDto>>
{
    public override void Configure()
    {
        Get("api/booking/GetDeal/{DealId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDealRequestDto idbooking, CancellationToken ct)
    {
        var results = await _service.GetDealAsync(idbooking);
        await SendAsync(results, cancellation: ct);
    }
}