using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;

namespace User.Api.Endpoints;

public class DeleteUser(IUserService service): Endpoint<DeleteUserRequest, UserDto>
{
    public override void Configure()
    {
        Post("/api/user/delete");
        Roles("admin");
    }
    public override async Task HandleAsync
        (DeleteUserRequest? request, CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var result = await service.DeleteUserAsync(request!.UserId);
        await SendAsync(result, cancellation: ct);
    }
}

public abstract record DeleteUserRequest
{
    [QueryParam] public required string UserId { get; set; }
}