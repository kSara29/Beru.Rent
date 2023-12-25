using Deal.Application.Contracts.Booking;
using Deal.Infrastructure.EfCoreDb;
using Microsoft.Extensions.DependencyInjection;

namespace Deal.Infrastructure;

public static class DependencyInjection
{
   public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
   {
      services.AddSingleton<IBookingRepository, EfBookingRepository>();
      return services;
   }
}