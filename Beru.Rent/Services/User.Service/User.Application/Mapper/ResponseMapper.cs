using Common;
using FluentValidation.Results;
using User.Application.Contracts;
using User.Dto.ResponseDto;

namespace User.Application.Mapper;

public class ResponseMapper : IResponseMapper
{
    public Task<ResponseModel<UserDtoResponce>> HandleFailedResponse(ValidationResult result)
    {
        var errors =
            result.Errors
                .Select(validationResultError => new ResponseError
                {
                    Code = validationResultError.PropertyName,
                    Message = validationResultError.ErrorMessage
                }).ToList();

        return Task.FromResult(ResponseModel<UserDtoResponce>.CreateFailed(errors));
    }
    
    public Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForPhone()
    {
        var errors = new List<ResponseError>();
        errors.Add(new ResponseError
        {
            Code = "phone",
            Message = "Данный номер телефона уже зарегистрирован."
        });
                
        return Task.FromResult(ResponseModel<UserDtoResponce>.CreateFailed(errors));
    }

    public Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForEmail()
    {
        var errors = new List<ResponseError>();
        errors.Add(new ResponseError
        {
            Code = "email",
            Message = "Данный почтовый адрес уже зарегистрирован."
        });
                
        return Task.FromResult(ResponseModel<UserDtoResponce>.CreateFailed(errors));
    }

    public Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForUserName()
    {
        var errors = new List<ResponseError>();
        errors.Add(new ResponseError
        {
            Code = "username",
            Message = "Данный логин уже зарегистрирован."
        });
                
        return Task.FromResult(ResponseModel<UserDtoResponce>.CreateFailed(errors));
    }
}