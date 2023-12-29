using System.ComponentModel.DataAnnotations;
using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.DTO;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace User.Api.Endpoints;

public class CreateUser(IUserService service) : Endpoint<CreateUserDto, ResponseModel<UserDto>>
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
        var err = ResponseModel<UserDto>.CreateFailed(new ResponseError
        {
            Code = "qwerty",
            Message = "Что-то не так"
        });
        if (!result.IsValid) await SendAsync(err, cancellation: ct);
        var user = await service.CreateUserAsync(model, model.Password);
        
        var res = ResponseModel<UserDto>.CreateSuccess(user.ToUserDto());
        await SendAsync(res, cancellation: ct);
    }
}