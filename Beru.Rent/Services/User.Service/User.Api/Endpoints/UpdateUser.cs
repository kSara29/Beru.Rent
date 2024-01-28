using Common;
using FastEndpoints;
using FluentValidation.Results;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Mapper;
using User.Dto;

namespace User.Api.Endpoints;

public class UpdateUser(IUserService service) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/update");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? model, CancellationToken ct)
    {
        UpdateUserValidation updateUserValidation = new UpdateUserValidation();
        ValidationResult result = updateUserValidation.Validate(model);
        
        if (!result.IsValid && result.Errors.Count > 0)
        {
            var responseFailed = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>());
            foreach (var validationFailure in result.Errors)
            {
                responseFailed.Errors!.Add(new ResponseError
                {
                    Code = validationFailure.PropertyName,
                    Message = validationFailure.ErrorMessage
                });
            }
            await SendAsync(responseFailed, cancellation: ct);
        }
        var results = await service.UpdateUserAsync(model!);
        var responseSuccess = ResponseModel<UserDtoResponce>.CreateSuccess(results.ToUserDto()!);
        await SendAsync(responseSuccess, cancellation: ct);
    }
}