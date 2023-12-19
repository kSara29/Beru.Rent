using Ad.Domain.Core.Enums;

namespace Ad.Infrastructure.Lib;

public class AdRepository : IAdRepository
{
    public Domain.Core.Models.Ad ArchiveAsync(Domain.Core.Models.Ad ad)
    {
        ad.State = AdState.Archive;
        return ad;
    }

    public Domain.Core.Models.Ad ActivateAsync(Domain.Core.Models.Ad ad)
    {
        ad.State = AdState.Active;
        return ad;
    }
}