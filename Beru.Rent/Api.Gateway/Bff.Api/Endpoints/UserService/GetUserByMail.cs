using Bff.Application.Contracts;
using Common;
using FastEndpoints;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Api.Endpoints.UserService;

public class GetUserByMail(IUserService service, ILogger<GetUserByMail> logger) : Endpoint<GetUserByEmailRequest, ResponseModel<UserDtoResponce>>
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
        var response = await service.GetUserByEmailAsync(request!.Email);
        
        logger.LogInformation("Ответ от userService: {@reposnse}", response);
        
        await SendAsync(response, cancellation: ct);
    }
}