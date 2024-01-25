using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class GetUserByMail(IUserService service): Endpoint<GetUserByEmailRequest, UserDto>
{
    public override void Configure()
    {
        Get("/api/user/getByMail");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByEmailRequest? request, CancellationToken ct)
    { 
        if (request is null) await SendAsync(null!, cancellation: ct);
        var result = await service.GetUserByMailAsync(request!.Email);
        await SendAsync(result, cancellation: ct);
    }
}

public abstract record GetUserByEmailRequest
{
    [QueryParam] public required string Email { get; init; }
}