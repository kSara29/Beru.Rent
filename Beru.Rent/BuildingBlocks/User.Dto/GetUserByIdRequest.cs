using FastEndpoints;

namespace User.Dto;

public record GetUserByIdRequest
{
    [QueryParam] public required string Id { get; init; }
};