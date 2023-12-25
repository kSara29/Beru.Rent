using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions.Validation;

namespace User.Api.Endpoints;

public class UpdateUser(IUserService service) : Endpoint<UpdateUserDto, object>
{
    public override void Configure()
    {
        Post("/api/user/update");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? model, CancellationToken ct)
    {
        if (model is null) await SendAsync(null!, cancellation: ct);
        var validateResult = model.UpdateUserValidate();
        if (validateResult!.Count > 0) await SendAsync(validateResult, cancellation: ct);

        var result = await service.UpdateUserAsync(model!);
        await SendAsync(result, cancellation: ct);
    }
}