using FastEndpoints;
using FluentValidation.Results;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Dto;

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
        UpdateUserValidation updateUserValidation = new UpdateUserValidation();
        ValidationResult result = updateUserValidation.Validate(model);
        // var validateResult = model.UpdateUserValidate();
        if (!result.IsValid) await SendAsync(result, cancellation: ct);
        var results = await service.UpdateUserAsync(model!);
        await SendAsync(results, cancellation: ct);
    }
}