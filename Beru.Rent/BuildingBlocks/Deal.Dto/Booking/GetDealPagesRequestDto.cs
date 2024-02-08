using FastEndpoints;

namespace Deal.Dto.Booking;

public record GetDealPagesRequestDto
{
    [QueryParam] public required string Id { get; init; }
    [QueryParam] public required int Page { get; init; }
};

