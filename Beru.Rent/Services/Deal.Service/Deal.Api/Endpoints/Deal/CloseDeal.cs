using Common;
using Deal.Application.Contracts.Deal;
using Deal.Dto.Booking;
using FastEndpoints;

namespace Deal.Api.Endpoints;

public class CloseDeal(IDealService _service): Endpoint<CloseDealRequestDto,ResponseModel<CloseDealResponseDto>>
{
    public override void Configure()
    {
        Get("api/deal/close");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CloseDealRequestDto dto, CancellationToken ct)
    {
        var results = await _service.CloseDealAsync(dto);
        await SendAsync(results, cancellation: ct);
    }
}