using FastEndpoints;

namespace User.Dto.RequestDto;

public record GetUserByIdRequest
{
    [QueryParam] public string? Id { get; set; }
};