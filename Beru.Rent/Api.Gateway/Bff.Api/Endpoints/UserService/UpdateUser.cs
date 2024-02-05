using Bff.Application.Contracts;
using Bff.Application.Validations;
using Common;
using FastEndpoints;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class UpdateUser(IUserService service, UpdateUserValidation updateUserValidation) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
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
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.UpdateUserAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}