using FastEndpoints;

namespace Deal.Dto.Booking;

public class GetDealPagesRequestDto
{
    [QueryParam] public required string? Id { get; set; }
    [QueryParam] public required int Page { get; set; }
};

