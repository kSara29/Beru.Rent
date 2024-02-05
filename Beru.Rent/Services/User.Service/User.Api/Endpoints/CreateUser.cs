using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Mapper;
using User.Application.Validation;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;
using IResponseMapper = User.Application.Contracts.IResponseMapper;

namespace User.Api.Endpoints;


public class CreateUser(
    IUserService service, 
    CreateUserValidation createUserValidation,
    IUserValidator validator, IResponseMapper mapper) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (CreateUserDto model, CancellationToken ct)
    {
        var validationResult = await createUserValidation.ValidateAsync(model, ct);
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
        
        var user = await service.CreateUserAsync(model, model.Password);
        var responseModel = ResponseModel<UserDtoResponce>.CreateSuccess(user.ToUserDtoResponse());
        await SendAsync(responseModel, cancellation: ct);
    }
}