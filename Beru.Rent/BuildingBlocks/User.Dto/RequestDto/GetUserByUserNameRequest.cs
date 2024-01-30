using FastEndpoints;

namespace User.Dto.RequestDto;

public record GetUserByUserNameRequest
{
    [QueryParam] public required string UserName { get; init; }
}