using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;

namespace Bff.Api.Endpoints.UserService;

public class DeleteUser(IUserService service) : Endpoint<DeleteUserByIdRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/bff/user/deleteUser");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (DeleteUserByIdRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.DeleteUserAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}