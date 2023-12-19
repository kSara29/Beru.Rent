namespace Ad.Application.Lib.Contracts.Ad;

public interface IAdRepository
{
    Task<bool> CreateAdAsync(Domain.Core.Models.Ad ad);
}