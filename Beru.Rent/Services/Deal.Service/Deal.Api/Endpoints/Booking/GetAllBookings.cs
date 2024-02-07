using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetAllBookings(IBookingService _service): Endpoint<RequestByUserId, ResponseModel<List<GetBookingResponseDto>>>
{
    public override void Configure()
    {
        Get("api/booking/getallbookings/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestByUserId id, CancellationToken ct)
    {
        var list = await _service.GetAllBookingsAsync(id);
        var result = ResponseModel<List<GetBookingResponseDto>>.CreateSuccess(list);
        await SendAsync(result, cancellation: ct);
    }
}