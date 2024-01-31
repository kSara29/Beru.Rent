using FastEndpoints;

namespace User.Dto;

public record GetUserByUserNameRequest
{
    [QueryParam] public required string UserName { get; init; }
}