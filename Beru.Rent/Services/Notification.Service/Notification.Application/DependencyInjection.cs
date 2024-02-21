using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Contracts;
using Notification.Application.Services;
using Notification.Dto.RequestDto;

namespace Notification.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<INotificationService<SendMessageRequestDto>, EmailNotificationService>();
        return service;
    }
}