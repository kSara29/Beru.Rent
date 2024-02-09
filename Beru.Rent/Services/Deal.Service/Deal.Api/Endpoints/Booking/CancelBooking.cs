using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class CancelBooking(IBookingService _service): Endpoint<RequestById, ResponseModel<BoolResponseDto>>
{
    public override void Configure()
    {
        Get("api/booking/cancel");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestById dto, CancellationToken ct)
    {
        var list = await _service.CancelBookingsAsync(dto);
        var result = ResponseModel<BoolResponseDto>.CreateSuccess(list);
        await SendAsync(result, cancellation: ct);
    }
}