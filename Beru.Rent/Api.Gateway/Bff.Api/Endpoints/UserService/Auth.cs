using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;

namespace Bff.Api.Endpoints.UserService;

public class Auth(IUserService service) : Endpoint<ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/bff/user/auth");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (ResponseModel<UserDtoResponce> req, CancellationToken ct)
    {
        var response = await service.GetAuthService();
        await SendAsync(response, cancellation: ct);
    }
}