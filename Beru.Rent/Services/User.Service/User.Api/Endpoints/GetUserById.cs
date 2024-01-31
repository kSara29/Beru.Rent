using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class GetUserById(IUserService service): Endpoint<GetUserByIdRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/api/user/getById");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByIdRequest? request, CancellationToken ct)
    {
        var result = await service.GetUserByIdAsync(request!.Id);

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
        var responseSuccess = ResponseModel<UserDtoResponce>.CreateSuccess(result!);
        await SendAsync(responseSuccess, cancellation: ct);
    }
}