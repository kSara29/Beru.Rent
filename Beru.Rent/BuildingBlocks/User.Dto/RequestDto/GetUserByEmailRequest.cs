using FastEndpoints;

namespace User.Dto.RequestDto;

public record GetUserByEmailRequest
{
    [QueryParam] public required string Email { get; init; }
};