using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;

namespace Bff.Api.Endpoints.UserService;

public class GetUserByName(IUserService service) : Endpoint<GetUserByUserNameRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/bff/user/getByName");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetUserByUserNameRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetUserByNameAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}