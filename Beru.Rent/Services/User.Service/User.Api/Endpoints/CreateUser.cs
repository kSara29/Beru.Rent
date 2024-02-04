using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Api.Endpoints;


public class CreateUser(
    IUserService service, 
    CreateUserValidation createUserValidation,
    IUserValidator validator) : Endpoint<CreateUserDto, ResponseModel<UserDtoResponce>>
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
        if (validationResult.IsValid)
        {
            var errors = new List<ResponseError>();
            foreach (var validationResultError in validationResult.Errors)
            {
                errors.Add(new ResponseError
                {
                    Code = validationResultError.PropertyName,
                    Message = validationResultError.ErrorMessage
                });
            }
            var responceModel = ResponseModel<UserDtoResponce>.CreateFailed(errors);
            await SendAsync(responceModel, cancellation: ct);
        }
        else
        {
            var phoneResult = await validator.FindUserByPhoneNumberAsync(model.Phone);
            if (!phoneResult)
            {
                var errors = new List<ResponseError>();
                errors.Add(new ResponseError
                {
                    Code = "phone",
                    Message = "Данный номер телефона уже зарегистрирован."
                });
                
                var response = ResponseModel<UserDtoResponce>.CreateFailed(errors);
                await SendAsync(response, cancellation: ct);
                return;
            }
            var phone = await service.CreateUserAsync(model, model.Password);
            var responseModel = ResponseModel<UserDtoResponce>.CreateSuccess(phone.ToUserDto());
            await SendAsync(responseModel, cancellation: ct);
        }
        
        // var result = await createUserValidation.ValidateAsync(model, ct);
        // if (!result.IsValid && result.Errors.Any())
        // {
        //     var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
        //     foreach (var validationFailure in result.Errors)
        //     {
        //         responce.Errors!.Add(new ResponseError
        //         {
        //             Code = validationFailure.PropertyName,
        //             Message = validationFailure.ErrorMessage
        //         });
        //     }
        //     await SendAsync(responce, cancellation: ct);
        //    return;
        // }
        //
        // var phoneValidateResult = await phoneUserValidator.ValidateAsync(model.Phone);
        // if (!phoneValidateResult.Succeeded && phoneValidateResult.Errors.Any())
        // {
        //     var responce = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
        //     foreach (var validationFailure in phoneValidateResult.Errors)
        //     {
        //         responce.Errors!.Add(new ResponseError
        //         {
        //             Code = validationFailure.Code,
        //             Message = validationFailure.Description
        //         });
        //     }
        //     await SendAsync(responce, cancellation: ct);
        //     return;
        // }
        // var user = await service.CreateUserAsync(model, model.Password);
        //
        // var res = ResponseModel<UserDtoResponce>.CreateSuccess(user.ToUserDto());
        // await SendAsync(res, cancellation: ct);
    }
}