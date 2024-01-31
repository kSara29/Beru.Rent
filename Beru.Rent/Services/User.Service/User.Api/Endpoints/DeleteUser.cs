using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class DeleteUser(IUserService service): Endpoint<DeleteUserByIdRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Post("/api/user/delete");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (DeleteUserByIdRequest request, CancellationToken ct)
    {
        var result = await service.DeleteUserAsync(request!.Id);
        if (result is null)
        {
            var responseFail = ResponseModel<UserDtoResponce>.CreateFailed(new List<ResponseError?>
                {
                    new()
                    {
                        Message = "Юзер не найден"
                    }
                }
            );
            await SendAsync(responseFail, cancellation: ct);
        }

        else
        {
            var responseSuccess = ResponseModel<UserDtoResponce>.CreateSuccess(result);
            await SendAsync(responseSuccess, cancellation: ct);
        }
    }
}