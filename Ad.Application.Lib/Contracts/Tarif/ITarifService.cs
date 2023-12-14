using Ad.Domain.Core.Models;

namespace Ad.Application.Lib.Contracts.Tarif;

public interface ITarifService
{
    Task CreateTarifAsync(Tariff tariff);
}