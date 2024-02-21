using Bff.Application.Contracts;
using Bff.Application.Validations;
using Common;
using FastEndpoints;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class CreateUser(IUserService service, CreateUserValidation userValidation, ILogger<CreateUser> logger) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/bff/user/createUser");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateUserDto? request, CancellationToken ct)
    { 
        var result = await userValidation.ValidateAsync(request, ct);
        if (!result.IsValid && result.Errors.Any())
        {
            var responseNotValid = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError>());
            foreach (var validationFailure in result.Errors)
            {
                responseNotValid.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }
            
            logger.LogError("Не все поля валидны {@response}", responseNotValid);
            
            await SendAsync(responseNotValid, cancellation: ct);
            return;
        }
        
        var response = await service.CreateUserAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}