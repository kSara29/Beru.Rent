namespace Deal.Application.Contracts.Deal;

public interface IDealService
{
    Task<bool> CreateDealAsync(Domain.Models.Deal deal);
}