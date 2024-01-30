using Common;
using Deal.Application.Contracts.Booking;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class GetBooking(IBookingService _service): Endpoint<RequestById, ResponseModel<GetBookingResponseDto>>
{
    public override void Configure()
    {
        Post("api/booking/getbookings/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RequestById id, CancellationToken ct)
    {
        var list = await _service.GetBookingAsync(id);
        var result = ResponseModel<GetBookingResponseDto>.CreateSuccess(list);
        await SendAsync(result, cancellation: ct);
    }
}