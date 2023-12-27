using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;

namespace User.Api.Endpoints;

public class GetUserById(IUserService service): Endpoint<UserDto>
{
    public override void Configure()
    {
        Post("/api/user/getById");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (UserDto? model, CancellationToken ct)
    { 
        if (model is null) await SendAsync(null!, cancellation: ct);
        var result = await service.GetUserByIdAsync(model.UserId);
        await SendAsync(result, cancellation: ct);
    }
}