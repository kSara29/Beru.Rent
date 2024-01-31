using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;

namespace Bff.Api.Endpoints.UserService;

public class GetUserById(IUserService service) : Endpoint<GetUserByIdRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/bff/user/getById");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetUserByIdRequest? request, CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetUserByIdAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}