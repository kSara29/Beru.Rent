using FastEndpoints;

namespace User.Dto.RequestDto;

public record GetUserByIdRequest{

    [QueryParam] public required string Id { get; init; }
};