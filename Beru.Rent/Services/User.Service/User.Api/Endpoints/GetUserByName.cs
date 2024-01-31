using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class GetUserByName(IUserService service): Endpoint<GetUserByUserNameRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/api/user/getByName");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByUserNameRequest? request, CancellationToken ct)
    {
        var result = await service.GetUserByNameAsync(request!.UserName);
        if (request is null)
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

        var responseSuccess = ResponseModel<UserDtoResponce>.CreateSuccess(result);
        
        await SendAsync(responseSuccess, cancellation: ct);
    }
}