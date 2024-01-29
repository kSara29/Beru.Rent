using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using User.Dto;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace User.Api.Endpoints;

public class CreateUser(IUserService service) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
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
        if (!result.IsValid && result.Errors.Count > 0)
        {
            var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
            foreach (var validationFailure in result.Errors)
            {
                responce.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }
            await SendAsync(responce, cancellation: ct);
        }
        var user = await service.CreateUserAsync(model, model.Password);
        
        var res = ResponseModel<UserDtoResponce>.CreateSuccess(user.ToUserDto()!);
        await SendAsync(res, cancellation: ct);
    }
}