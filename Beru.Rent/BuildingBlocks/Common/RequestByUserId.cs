using FastEndpoints;

namespace Common;

public record RequestByUserId
{
    [QueryParam] public required string Id { get; init; }
};