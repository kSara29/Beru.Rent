using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.Services;
using Common;
using Deal.Dto.Booking;
using Microsoft.Extensions.DependencyInjection;
using User.Dto;

namespace Bff.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<ServiceHandler<UserDtoResponce>>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAdService, AdService>();
        return service;
    }
}