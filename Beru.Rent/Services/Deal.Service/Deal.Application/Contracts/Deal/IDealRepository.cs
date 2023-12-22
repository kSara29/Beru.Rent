namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<bool> CreateDealAsync(Domain.Models.Deal deal);
}