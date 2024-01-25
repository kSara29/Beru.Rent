using Bff.Application.Contracts;
using Bff.Application.Maping;
using Bff.Application.Services;
using Deal.Dto.Booking;
using Microsoft.Extensions.DependencyInjection;
using User.Dto;

namespace Bff.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<ServiceMaping<UserDtoResponce>>();
        service.AddScoped<ServiceMaping<BookingDto>>();
        service.AddScoped<ServiceMaping<GetAllBookingDto>>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IDealServiceGet, DealServiceGet>();
        service.AddScoped<IDealServiceCreate, DealServiceCreate>();
        return service;
    }
}