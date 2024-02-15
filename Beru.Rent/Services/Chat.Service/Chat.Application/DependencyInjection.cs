using Chat.Application.Contracts;
using Chat.Application.Message;
using Chat.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddSingleton<IChatService, ChatService>();
        services.AddSingleton<MessageConsumer>();
        return services;
    }
}