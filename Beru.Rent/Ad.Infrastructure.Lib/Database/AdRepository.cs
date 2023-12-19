using Ad.Application.Lib.Contracts.Ad;

namespace Ad.Infrastructure.Lib.Database;

public class AdRepository : IAdRepository
{
    public Task<bool> CreateAdAsync(Domain.Core.Models.Ad ad)
    {
        Console.WriteLine("saving ad in db");
        throw new NotImplementedException();
    }

    public Domain.Core.Models.Ad ArchiveAsync(Domain.Core.Models.Ad ad)
    {
        throw new NotImplementedException();
    }

    public Domain.Core.Models.Ad ActivateAsync(Domain.Core.Models.Ad ad)
    {
        throw new NotImplementedException();
    }
}