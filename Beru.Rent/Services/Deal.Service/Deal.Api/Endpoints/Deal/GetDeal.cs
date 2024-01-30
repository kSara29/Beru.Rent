using Common;
using Deal.Application.Contracts.Deal;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetDeal(IDealService _service): Endpoint<GetDealRequestDto, ResponseModel<GetDealResponseDto>>
{
    public override void Configure()
    {
        Post("api/booking/createDeal/{idbooking}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Guid idbooking, CancellationToken ct)
    {
        var results = await _service.CreateDealAsync(idbooking);
        var res = ResponseModel<GetDealResponseDto>.CreateSuccess(results);
        await SendAsync(res, cancellation: ct);
    }
}