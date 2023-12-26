using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions.Validation;

namespace User.Api.Endpoints;

public class CreateUser(IUserService service) : Endpoint<CreateUserDto, object>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateUserDto model, CancellationToken ct)
    {
        var result = model.CreateUserValidate();
        if (result!.Count > 0) await SendAsync(result, cancellation: ct);
        var results = await service.CreateUserAsync(model, model.Password);
        await SendAsync(results, cancellation: ct);
    }
}