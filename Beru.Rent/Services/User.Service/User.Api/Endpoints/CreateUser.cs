using System.ComponentModel.DataAnnotations;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions.Validation;
using ValidationResult = FluentValidation.Results.ValidationResult;

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
        CreateUserValidation createUserValidation = new CreateUserValidation();
        ValidationResult result = createUserValidation.Validate(model);
        // var result = model.CreateUserValidate();
        if (!result.IsValid) await SendAsync(result.Errors, cancellation: ct);
        var results = await service.CreateUserAsync(model, model.Password);
        await SendAsync(results, cancellation: ct);
    }
}