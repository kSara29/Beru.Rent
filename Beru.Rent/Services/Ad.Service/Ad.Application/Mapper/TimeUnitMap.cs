using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;

namespace Ad.Application.Mapper;

public static class TimeUnitMap
{
    public static TimeUnit ToDomain(this CreateTimeUnitDto dto)
    {
        return new TimeUnit
        {
            Title = dto.Title,
            Duration = TimeSpan.Parse(dto.Duration),
            CreatedAt = DateTime.Now
        };
    }
    
    public static TimeUnitDto ToDto(this TimeUnit model)
    {
        return new TimeUnitDto
        {
            Title = model.Title,
            Duration = model.Duration,
            CreatedAt = model.CreatedAt,
            Id = model.Id
        };
    }
}