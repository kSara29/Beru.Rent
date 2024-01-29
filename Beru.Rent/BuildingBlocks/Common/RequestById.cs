using FastEndpoints;

namespace Common;


public record RequestById
{
    [QueryParam] public required Guid Id { get; init; }
};