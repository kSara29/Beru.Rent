using Common;
using FluentValidation.Results;
using User.Dto.ResponseDto;

namespace User.Application.Contracts;

public interface IResponseMapper
{
    Task<ResponseModel<UserDtoResponce>> HandleFailedResponse(ValidationResult result);
    Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForPhone();
    Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForEmail();
    Task<ResponseModel<UserDtoResponce>> HandleFailedResponseForUserName();
}