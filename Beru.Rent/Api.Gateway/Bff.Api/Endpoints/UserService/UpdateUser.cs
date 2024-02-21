using Bff.Application.Contracts;
using Bff.Application.Validations;
using Common;
using FastEndpoints;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class UpdateUser(IUserService service, UpdateUserValidation updateUserValidation, 
    ILogger<UpdateUser> logger) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/bff/user/updateUser");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? request, CancellationToken ct)
    { 
        var result = await updateUserValidation.ValidateAsync(request, ct);
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
        
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.UpdateUserAsync(request!);
        logger.LogInformation("Ответ от userService: {@reposnse}", response);
        
        await SendAsync(response, cancellation: ct);
    }
}