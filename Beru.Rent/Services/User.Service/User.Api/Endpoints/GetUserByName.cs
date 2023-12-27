using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;

namespace User.Api.Endpoints;

public class GetUserByName(IUserService service): Endpoint<UserDto>
{
    public override void Configure()
    {
        Post("/api/user/getByName");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (UserDto? model, CancellationToken ct)
    { 
        if (model is null) await SendAsync(null!, cancellation: ct);
        var result = await service.GetUserByNameAsync(model.UserName);
        await SendAsync(result, cancellation: ct);
    }
}