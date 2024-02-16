using Microsoft.Extensions.DependencyInjection;
using Notification.Appl.Services;
using Notification.Application.Contracts;

namespace Notification.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<INotificationService<EmailNotificationService>>();
        return service;
    }
}