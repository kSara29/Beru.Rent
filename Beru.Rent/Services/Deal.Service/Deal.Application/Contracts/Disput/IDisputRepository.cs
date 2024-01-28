namespace Deal.Application.Contracts.Disput;

public interface IDisputRepository
{
    Task<bool> CreateDisputAsync(Domain.Models.Disput disput);
    Task<bool> CloseDisputAsync(Domain.Models.Disput disput);
}