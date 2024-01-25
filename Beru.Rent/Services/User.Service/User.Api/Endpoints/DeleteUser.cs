using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class DeleteUser(IUserService service): Endpoint<DeleteUserByIdRequest, UserDtoResponce>
{
    public override void Configure()
    {
        Post("/api/user/delete");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (DeleteUserByIdRequest? request, CancellationToken ct)
    {
        if (request is null) await SendAsync(null!, cancellation: ct);
        var result = await service.DeleteUserAsync(request!.Id);
        await SendAsync(result, cancellation: ct);
    }
}