using Deal.Application.Contracts.Disput;
using Deal.Domain.Models;

namespace Deal.Application.Services;

public class DisputService : IDisputService
{
    private readonly IDisputRepository _disputRepository;

    public DisputService(IDisputRepository disputRepository)
    {
        _disputRepository = disputRepository;
    }

    public async Task<bool> CreateDisputAsync(Disput disput)
    {
        return await (_disputRepository.CreateDisputAsync(disput));
    }

    public async Task<bool> CloseDisputAsync(Disput disput)
    {
        return await (_disputRepository.CloseDisputAsync(disput));
    }
}