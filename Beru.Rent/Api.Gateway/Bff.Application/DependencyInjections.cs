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
        service.AddScoped<ServiceHandler<UserDtoResponce>>();
       
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAdService, AdService>(); 
        service.AddScoped<ICategoryService, CategoryService>(); 
        service.AddScoped<ITimeUnitService, TimeUnitService>(); 
        service.AddScoped<IFileService, FileService>(); 
        service.AddScoped<ServiceHandler<GuidResponse>>();
        service.AddScoped<ServiceHandler<StringResponse>>();
        service.AddScoped<ServiceHandler<AdDto>>();
        service.AddScoped<ServiceHandler<List<CategoryDto?>>>();
        service.AddScoped<ServiceHandler<CategoryDto?>>();
        service.AddScoped<ServiceHandler<List<TimeUnitDto?>>>();
        service.AddScoped<ServiceHandler<TimeUnitDto?>>();
        service.AddScoped<ServiceHandler<GetMainPageDto<AdMainPageDto>>>();
        service.AddScoped<ServiceHandler<DecimalResponse>>();
        service.AddScoped<ServiceHandler<byte[]?>>();
        service.AddScoped<IBookingService, BookingService>();
        return service;
    }
}