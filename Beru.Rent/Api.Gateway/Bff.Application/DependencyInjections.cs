using Bff.Application.Contracts;
using Bff.Application.Handlers;
using Bff.Application.Services;
using Bff.Application.Validations;
using Microsoft.Extensions.DependencyInjection;
using User.Dto;

namespace Bff.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddHttpClient();
        service.AddSingleton<ServiceHandler>();
        service.AddSingleton<IUserService, UserService>();
        service.AddSingleton<IAdService, AdService>(); 
        service.AddSingleton<IAddressService, AddressService>(); 
        service.AddSingleton<ICategoryService, CategoryService>(); 
        service.AddSingleton<ITimeUnitService, TimeUnitService>(); 
        service.AddSingleton<IFileService, FileService>(); 
        service.AddScoped<IBookingService, BookingService>();
        service.AddScoped<CreateUserValidation>();
        service.AddScoped<UpdateUserValidation>();
        service.AddSingleton<IBookingService, BookingService>();
        service.AddSingleton<IDealService, DealService>();
        service.AddSingleton<IChatService, ChatService>();
        return service;
    }
}