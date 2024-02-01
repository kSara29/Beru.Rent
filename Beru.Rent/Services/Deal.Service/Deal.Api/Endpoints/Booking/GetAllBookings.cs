using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetAllBookings(IBookingService _service): Endpoint<RequestByUserId, ResponseModel<List<GetAllBookingsResponseDto>>>
{
    public override void Configure()
    {
        Post("api/booking/getallbookings/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestByUserId id, CancellationToken ct)
    {
        var list = await _service.GetAllBookingsAsync(id);
        var result = ResponseModel<List<GetAllBookingsResponseDto>>.CreateSuccess(list);
        await SendAsync(result, cancellation: ct);
    }
}