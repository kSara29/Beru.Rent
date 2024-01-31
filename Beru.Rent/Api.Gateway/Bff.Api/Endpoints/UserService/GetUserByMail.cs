using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;

namespace Bff.Api.Endpoints.UserService;

public class GetUserByMail(IUserService service) : Endpoint<GetUserByEmailRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/bff/user/getByMail");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync
        (GetUserByEmailRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var response = await service.GetUserByEmailAsync(request!);
        await SendAsync(response, cancellation: ct);
    }
}