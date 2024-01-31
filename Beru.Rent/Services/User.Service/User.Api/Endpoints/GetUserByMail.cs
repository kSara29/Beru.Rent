using Common;
using FastEndpoints;
using User.Application.Contracts;
using User.Dto;

namespace User.Api.Endpoints;

public class GetUserByMail(IUserService service): Endpoint<GetUserByEmailRequest, ResponseModel<UserDtoResponce>>
{
    public override void Configure()
    {
        Get("/api/user/getByMail");
        AllowAnonymous();
    }
    public override async Task HandleAsync
        (GetUserByEmailRequest? request, CancellationToken ct)
    {
        var result = await service.GetUserByMailAsync(request!.Email);
        
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

        var responseSuccess = ResponseModel<UserDtoResponce>.CreateSuccess(result);
        
        await SendAsync(responseSuccess, cancellation: ct);
    }
}