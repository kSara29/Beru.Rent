using Ad.Domain.Models;
using Ad.Dto.CreateDtos;

namespace Ad.Api.Mapper;

public static class TariffMapper
{
    public static Tariff? ToDomain(this CreateTarifDto? model)
    {
        return model is null
            ? null
            : new Tariff
            {
                CreatedAt = DateTime.Now,
                Duration = model.Duration,
                Id = Guid.NewGuid(),
                Title = model.Name,
                Price = model.Price
            };
    }
}