using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions;

namespace User.Api.Endpoints;

public class DeleteUser(IUserService service): Endpoint<UserDto>
{
    public override void Configure()
    {
        Post("/api/user/delete");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (UserDto? model, CancellationToken ct)
    {
        if (model is null) await SendAsync(null!, cancellation: ct);
        var result = await service.DeleteUserAsync(model.UserId);
        await SendAsync(result, cancellation: ct);
    }
}