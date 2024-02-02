using Common;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Api.Endpoints;


public class CreateUser(
    IUserService service, 
    CreateUserValidation createUserValidation,
    PhoneNumberValidation phoneUserValidator,
    UserManager<Domain.Models.User> manager) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
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
            return;
        }
        
        var result = await createUserValidation.ValidateAsync(model, ct);
        if (!result.IsValid && result.Errors.Any())
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
           return;
        }
        
        var phoneValidateResult = await phoneUserValidator.ValidateAsync(manager, new Domain.Models.User
        {
            Iin = model.Iin,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.Phone
        });
        if (!phoneValidateResult.Succeeded && phoneValidateResult.Errors.Any())
        {
            var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
            foreach (var validationFailure in phoneValidateResult.Errors)
            {
                responce.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.Code,
                    Message = validationFailure.Description
                });
            }
            await SendAsync(responce, cancellation: ct);
            return;
        }
        var user = await service.CreateUserAsync(model, model.Password);
        
        var res = ResponseModel<UserDtoResponce>.CreateSuccess(user.ToUserDto()!);
        await SendAsync(res, cancellation: ct);
    }
}