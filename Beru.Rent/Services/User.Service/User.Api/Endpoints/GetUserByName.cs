using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class GetUserByName(IUserService service): Endpoint<GetUserByUserNameRequest, UserDtoResponce>
{
    public override void Configure()
    {
        Get("/api/user/getByName");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByUserNameRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var result = await service.GetUserByNameAsync(request!.UserName);
        await SendAsync(result, cancellation: ct);
    }
}