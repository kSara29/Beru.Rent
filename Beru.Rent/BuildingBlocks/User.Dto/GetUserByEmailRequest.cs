using FastEndpoints;

namespace User.Dto;

public record GetUserByEmailRequest
{
    [QueryParam] public required string Email { get; init; }
};