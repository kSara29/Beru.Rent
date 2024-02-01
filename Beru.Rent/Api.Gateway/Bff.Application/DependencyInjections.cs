using Ad.Application.DTO.GetDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
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
        service.AddSingleton<ServiceHandler>();
        service.AddSingleton<IUserService, UserService>();
        service.AddSingleton<IAdService, AdService>(); 
        service.AddSingleton<IAddressService, AddressService>(); 
        service.AddSingleton<ICategoryService, CategoryService>(); 
        service.AddSingleton<ITimeUnitService, TimeUnitService>(); 
        service.AddSingleton<IFileService, FileService>(); 
        service.AddScoped<IBookingService, BookingService>();
        return service;
    }
}