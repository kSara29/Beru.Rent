using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Validation;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;
using IResponseMapper = User.Application.Contracts.IResponseMapper;

namespace User.Api.Endpoints;

public class UpdateUser(IUserService service, 
    UpdateUserValidation updateUserValidation,
    IUserValidator validator, IResponseMapper mapper) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/update");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? model, CancellationToken ct)
    {
        var validationResult = await updateUserValidation.ValidateAsync(model, ct);
        if (!validationResult.IsValid)
        {
            var resp = await mapper
                .HandleFailedResponse(validationResult);
            await SendAsync(resp, cancellation: ct);
            return;
        }
        
        var phoneResult = await validator.FindUserByPhoneNumberAsync(model.Phone);
        if (phoneResult)
        {
            var resp = await mapper
                .HandleFailedResponseForPhone();
            await SendAsync(resp, cancellation: ct);
            return;
        }
        
        var mailResult = await validator.FindUserByEmailNumberAsync(model.Mail);
        if (mailResult is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForEmail();
            await SendAsync(resp, cancellation: ct);
            return;
        }
        
        var userNameResult = await validator.FindUserByUserNameAsync(model.UserName);
        if (userNameResult is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForUserName();
            await SendAsync(resp, cancellation: ct);
            return;
        }
        
        ResponseModel<UserDtoResponce> response = await service.UpdateUserAsync(model);
        await SendAsync(response, cancellation: ct);
    }
}