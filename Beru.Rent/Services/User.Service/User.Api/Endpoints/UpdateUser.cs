using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Application.Mapper;
using User.Application.Validation;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Api.Endpoints;

public class UpdateUser(IUserService service, UpdateUserValidation updateUserValidation) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/update");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? model, CancellationToken ct)
    {
        var results = await service.UpdateUserAsync(model);
        await SendAsync(results, cancellation: ct);
    }
}