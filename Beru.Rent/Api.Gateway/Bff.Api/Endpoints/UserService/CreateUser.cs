using Bff.Application.Contracts;
using Bff.Application.Validations;
using Common;
using FastEndpoints;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class CreateUser(IUserService service, CreateUserValidation userValidation) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
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
            var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError>());
            foreach (var validationFailure in result.Errors)
            {
                responce.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }
            await SendAsync(responce, cancellation: ct);
            return;
        }
        var response = await service.CreateUserAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}