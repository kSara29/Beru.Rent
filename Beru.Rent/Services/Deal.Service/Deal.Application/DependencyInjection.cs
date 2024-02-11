using Deal.Application.Contracts.Booking;
using Deal.Application.Contracts.Deal;
using Deal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Deal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<IDealService, DealService>();
        service.AddScoped<IBookingService, BookingService>();
        
        service.AddSingleton<IMessagePublisher, MessagePublisher>((serviceProvider) =>
        {
            var hostname = "amqp://guest:guest@localhost:5672";
            var publisher = new MessagePublisher(hostname);
            return publisher;
        });

        return service;
    }
}