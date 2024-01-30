using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class UpdateUser(IUserService service) : Endpoint<UpdateUserDto, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
            Post("/bff/user/updateUser");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (UpdateUserDto? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.UpdateUserAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}