namespace Deal.Application.Contracts.Disput;

public interface IDisputService
{
    Task<bool> CreateDisputAsync(Domain.Models.Disput disput);
    Task<bool> CloseDisputAsync(Domain.Models.Disput disput);
}