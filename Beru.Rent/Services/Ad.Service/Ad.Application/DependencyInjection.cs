using Ad.Application.Contracts.Address;
using Ad.Application.Contracts.File;
using Ad.Application.Contracts.Tag;
using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Services;
using Ad.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<ITarifService, TarifService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAdService, AdService>();
        services.AddScoped<IAddressService<CreateAddressMainDto,AddressMainDto>, AddressMainService>();
        services.AddScoped<IAddressService<CreateAddressExtraDto,AddressExtraDto>, AddressExtraService>();
        return services;
    }
}