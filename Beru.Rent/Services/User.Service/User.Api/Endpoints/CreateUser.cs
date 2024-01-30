using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace User.Api.Endpoints;

public class CreateUser(IUserService service, CreateUserValidation createUserValidation) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateUserDto model, CancellationToken ct)
    {
        var userEmail = await service.GetUserByMailAsync(model.Mail);
        if (userEmail is not null)
        {
            var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>
            {
                new()
                {
                    Code = nameof(model.Mail),
                    Message = "Данный адрес электронной почты уже занят"
                }
            });
            await SendAsync(responce, cancellation: ct);
        }
        var result = createUserValidation.Validate(model);
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