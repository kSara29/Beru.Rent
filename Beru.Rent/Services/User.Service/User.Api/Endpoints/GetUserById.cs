using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;

namespace User.Api.Endpoints;

public class GetUserById(IUserService service): Endpoint<GetUserByIdRequest, UserDto>
{
    public override void Configure()
    {
        Get("/api/user/getById");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByIdRequest request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var result = await service.GetUserByIdAsync(request.Id);
        await SendAsync(result, cancellation: ct);
    }
}

public record GetUserByIdRequest
{
    [QueryParam] public required string Id { get; set; }
}