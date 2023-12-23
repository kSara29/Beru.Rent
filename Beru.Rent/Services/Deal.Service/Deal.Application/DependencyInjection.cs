using Deal.Application.Contracts.Booking;
using Deal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Deal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddSingleton<IBookingService, BookingService>();
        return service;
    }
}