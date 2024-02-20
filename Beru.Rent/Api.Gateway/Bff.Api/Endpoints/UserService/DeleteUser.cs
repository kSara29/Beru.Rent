using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class DeleteUser(IUserService service, ILogger<DeleteUser> logger) : Endpoint<DeleteUserByIdRequest, ResponseModel<UserDtoResponce>>
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
        
        logger.LogInformation("Ответ от userService: {@reposnse}", response);
        await SendAsync(response, cancellation: ct);
    }
}